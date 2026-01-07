using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace KT_Data_Support_main
{
    public partial class Form1 : Form
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,  // Включаем красивое форматирование
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull  // Игнорируем null значения
        };
        static string dir_name = "./info/";
        List<string> weapon_rules = new List<string> { };
        List<string> temp_operative_abilities = new List<string> { };
        List<string> temp_team_rules = new List<string> { };
        List<string> temp_team_equips = new List<string> { };
        List<string> temp_team_ploys = new List<string> { };

        static List<Team> update_current_teams_list(string current_path)
        {
            using (FileStream fs = new FileStream(current_path, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<List<Team>>(fs);
            }
        }
        static List<Operative> update_current_operatives_list(string current_path)
        {
            using (FileStream fs = new FileStream(current_path, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<List<Operative>>(fs);
            }
        }
        static List<Weapon> update_current_weapons_list(string current_path)
        {
            using (FileStream fs = new FileStream(current_path, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<List<Weapon>>(fs);
            }
        }

        List<Weapon> current_weapons_list = new List<Weapon> { };
        List<Operative> current_operatives_list = new List<Operative> { };
        List<Team> current_teams_list = new List<Team> { };

        public Form1()
        {
            InitializeComponent();

            // Проверка наличия необходимых файлов
            string[] files = Directory.GetFiles(dir_name);
            if (files.Contains(dir_name + "weapon_rules.txt"))
            {
                using (StreamReader reader = new StreamReader(dir_name + "weapon_rules.txt"))
                {
                    string text = reader.ReadToEnd().ToString();
                    foreach (string s in text.Split('!'))
                    {
                        weapon_rules.Add(s);
                    }
                }
            }
            else
            {
                Console.WriteLine("Error! Check 'weapon_rules.txt' file on the availability of all necessary rules");
            }

            if (files.Contains(dir_name + "kill_teams.json"))
            {
                current_teams_list = update_current_teams_list(dir_name + "kill_teams.json");
            }
            else
            {
                using (FileStream fs = new FileStream(dir_name + "kill_teams.json", FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(fs, current_teams_list, options);
                }
            }

            if (files.Contains(dir_name + "operatives.json"))
            {
                current_operatives_list = update_current_operatives_list(dir_name + "operatives.json");
            }
            else
            {
                using (FileStream fs = new FileStream(dir_name + "operatives.json", FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(fs, current_operatives_list, options);
                }
            }

            if (files.Contains(dir_name + "weapons.json"))
            {
                current_weapons_list = update_current_weapons_list(dir_name + "weapons.json");
            }
            else
            {
                using (FileStream fs = new FileStream(dir_name + "weapons.json", FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(fs, current_weapons_list, options);
                }
            }

            foreach (Team ct in current_teams_list)
            {
                listBox_Teams.Items.Insert(ct.id - 1, ct.id.ToString() + ": " + ct.Name);
            }
            foreach (Operative co in current_operatives_list)
            {
                listBox_Operatives.Items.Insert(co.id - 1, co.id.ToString() + ": " + co.Name);
            }
            foreach (Weapon cw in current_weapons_list)
            {
                listBox_Weapons.Items.Insert(cw.id - 1, cw.id.ToString() + ": " + cw.Name);
            }
        }

        private void listBox_Weapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Weapons.SelectedItem != null)
            {
                listBox_Operatives.SelectedItems.Clear();
                listBox_Teams.SelectedItems.Clear();
                Full_output_weapon_box.Visible = true;
                Full_output_operative_box.Visible = false;
                Full_output_team_box.Visible = false;
                foreach (Weapon w in current_weapons_list)
                {
                    if ((w.id.ToString() + ": " + w.Name) == listBox_Weapons.SelectedItem.ToString())
                    {
                        Full_output_weapon_ID.Text = "ID: " + w.id.ToString();
                        Full_output_weapon_team_name.Text = "Team name: " + w.Team_name;
                        Full_output_weapon_type.Text = "Type: " + w.Type;
                        Full_output_weapon_name.Text = "Name: " + w.Name;
                        Full_output_weapon_attack.Text = "Attack stat: " + w.Attack.ToString();
                        Full_output_weapon_hit.Text = "Hit stat: " + w.Hit.ToString() + "+";
                        Full_output_weapon_damage.Text = "Damage: " + w.Normal_damage.ToString() + " / " + w.Critical_damage.ToString();
                        Full_output_weapon_rules_box.Items.Clear();
                        foreach (string r in w.Rules)
                        {
                            Full_output_weapon_rules_box.Items.Add(r);
                        }
                        break;
                    }
                }
            }
        }

        private void Full_output_weapon_rules_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            string choosen_rule = Full_output_weapon_rules_box.SelectedItem.ToString().Split(' ')[0];
            foreach (string s in weapon_rules)
            {
                if (s.Contains(choosen_rule))
                {
                    Rule_description.Text = s;
                    break;
                }
            }
            Console.WriteLine(choosen_rule);
        }

        private void listBox_Operatives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Operatives.SelectedItem != null)
            {
                listBox_Weapons.SelectedItems.Clear();
                listBox_Teams.SelectedItems.Clear();
                Full_output_operative_box.Visible = true;
                Full_output_weapon_box.Visible = false;
                Full_output_team_box.Visible = false;
                foreach (Operative op in current_operatives_list)
                {
                    if ((op.id.ToString() + ": " + op.Name) == listBox_Operatives.SelectedItem.ToString())
                    {
                        Full_output_operative_ID.Text = "ID: " + op.id.ToString();
                        Full_output_operative_team_name.Text = "Team name: " + op.Team_name;
                        Full_output_operative_name.Text = "Name: " + op.Name;
                        Full_output_operative_apl.Text = "APL stat: " + op.APL.ToString();
                        Full_output_operative_move.Text = "Move stat: " + op.Move.ToString();
                        Full_output_operative_save.Text = "Save stat: " + op.Save.ToString();
                        Full_output_operative_wounds.Text = "Wound stat: " + op.Wounds.ToString();
                        Full_output_operative_weapons_box.Items.Clear();
                        foreach (int wid in op.Weapons_id)
                        {
                            Full_output_operative_weapons_box.Items.Add(current_weapons_list[wid-1].Name);
                        }
                        temp_operative_abilities = new List<string>(op.Abilities.Split('\n'));
                        Full_output_operative_abilities_box.Items.Clear();
                        foreach (string ab in temp_operative_abilities)
                        {
                            Full_output_operative_abilities_box.Items.Add(ab.Split(':')[0]); // Запись названий способностей
                        }
                        Full_output_operative_keywords.Text = string.Join(", ", op.Keywords);
                        break;
                    }
                }
            }
        }

        private void Full_output_operative_abilities_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string s in temp_operative_abilities)
            {
                if (s.Contains(Full_output_operative_abilities_box.SelectedItem.ToString()))
                {
                    Rule_description.Text = s.Replace(": ", "\n");
                    break;
                }
            }
        }

        private void listBox_Teams_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Teams.SelectedItem != null)
            {
                listBox_Weapons.SelectedItems.Clear();
                listBox_Operatives.SelectedItems.Clear();
                Full_output_team_box.Visible = true;
                Full_output_weapon_box.Visible = false;
                Full_output_operative_box.Visible = false;
                foreach (Team t in current_teams_list)
                {
                    if ((t.id.ToString() + ": " + t.Name) == listBox_Teams.SelectedItem.ToString())
                    {
                        Full_output_team_ID.Text = "ID: " + t.id.ToString();
                        Full_output_team_name.Text = "Name: " + t.Name;

                        temp_team_rules = new List<string>(t.Rules.Split('?'));
                        Full_output_team_rules_box.Items.Clear();
                        foreach (string ru in temp_team_rules)
                        {
                            Full_output_team_rules_box.Items.Add(ru.Split('!')[0]); // Запись названий правил
                        }

                        int ploys_count = t.Ploys.Count;
                        temp_team_ploys = new List<string> { };
                        Full_output_team_stratagem_box.Items.Clear();
                        for (int i = 0; i < ploys_count; i++)
                        {
                            temp_team_ploys.Add($"!{t.Ploys[i].Type}!\n{t.Ploys[i].Name}\n{t.Ploys[i].Content}");
                            Full_output_team_stratagem_box.Items.Add($"{t.Ploys[i].Type}-{t.Ploys[i].Name}");
                        }

                        temp_team_equips = new List<string>(t.Faction_equipment.Split('?'));
                        Full_output_team_equipment_box.Items.Clear();
                        foreach (string eq in temp_team_equips)
                        {
                            Full_output_team_equipment_box.Items.Add(eq.Split('!')[0]); // Запись названий снаряжения
                        }
                        Full_output_team_datacards_box.Items.Clear();
                        foreach (int opid in t.Datacards)
                        {
                            Full_output_team_datacards_box.Items.Add(current_operatives_list[opid - 1].Name);
                        }
                        Full_output_team_archetypes.Text = "Archetypes: " + t.Archetypes;
                        break;
                    }
                }
            }
        }

        private void Full_output_team_rules_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string s in temp_team_rules)
            {
                if (s.Contains(Full_output_team_rules_box.SelectedItem.ToString()))
                {
                    Rule_description.Text = s.Replace("!", "\n");
                    break;
                }
            }
        }

        private void Full_output_team_equipment_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string s in temp_team_equips)
            {
                if (s.Contains(Full_output_team_equipment_box.SelectedItem.ToString()))
                {
                    Rule_description.Text = s.Replace("!", "\n");
                    break;
                }
            }
        }

        private void Full_output_team_stratagem_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (string s in temp_team_ploys)
            {
                if (s.Contains(Full_output_team_stratagem_box.SelectedItem.ToString().Split('-')[1]))
                {
                    Rule_description.Text = s;
                    break;
                }
            }
        }
    }

    class Stratagem //содержит данные о стратагемах
    {
        public string Type { get; set; }  // содержит тип стратагемы "Strategy ploy"/"Firefight ploy"
        public string Name { get; set; }  // содержит название стратагемы
        public string Content { get; set; }  // содержит описание действий стратагемы
    }

    class Team //содержит данные о игровой команде
    {
        public int id { get; set; } // Id команды
        public string Name { get; set; }  // содержит название команды
        public string Rules { get; set; }  // содержит правила команды. Данные записываются в формате: "название!содержание?название2!содержание2?..."
        public List<Stratagem> Ploys { get; set; } // содержит стратагемы
        public string Faction_equipment { get; set; } // содержит фракционное снаряжение. Данные записываются в формате: "название!содержание?название2!содержание2?..."
        public string Archetypes { get; set; } // содержит архетипы команд для выбора миссий. Данные записываются в формате: "архетип1 / архетип2"
        public List<int> Datacards { get; set; } // содержит id моделей, относящихся к данной команде
    }

    class Operative
    {
        public int id { get; set; } // Id оперативника
        public string Team_name { get; set; }  // К какой команде относится
        public string Name { get; set; }  // Имя оперативника
        public int APL { get; set; }  // APL стат оперативника
        public int Move { get; set; }  // Move стат оперативника
        public int Save { get; set; }  // Save стат оперативника
        public int Wounds { get; set; }  // Показатель здоровья оперативника
        public List<int> Weapons_id { get; set; }  // Список id оружия
        public string Abilities { get; set; }  // Список способностей оперативника
        public List<string> Keywords { get; set; }  // Список ключевых слов оперативника
    }

    class Weapon
    {
        public int id { get; set; } // Id оружия
        public string Team_name { get; set; }  // К какой команде относится
        public string Type { get; set; }  // Тип оружия. Значения м.б. только: "Ranged"/"Melee"
        public string Name { get; set; }  // Название оружия
        public int Attack { get; set; }  // Показатель атаки оружия
        public int Hit { get; set; }  // Показатель попадания оружия
        public int Normal_damage { get; set; }  // Показатель нормального урона оружия
        public int Critical_damage { get; set; }  // Показатель критического урона оружия
        public List<string> Rules { get; set; }  // Дополнительные правила оружия оружия. Формат строки: "Название\nсодержание\n\nНазвание2\nсодержание2\n\n..."
    }
}
