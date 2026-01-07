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
using System.Xml.Linq;
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

        static string add_new_team(JsonSerializerOptions options, string path, List<Team> current_kill_teams, string name, string rules, List<Stratagem> ploys, string faction_equip, string archetypes, List<int> operatives_id)
        {
            // проверки на пустые поля
            if (name is null | name == "")
            {
                return "Empty team name";
            }
            if (rules is null | rules == "")
            {
                return "Empty team rules. Min 1 required!";
            }
            if (ploys.Count == 0)
            {
                return "Wrong ploys quantity. Min 1 stratagem required!";
            }
            if (faction_equip is null | faction_equip == "")
            {
                return "Wrong faction equipment. Min 1 faction equipment required!";
            }
            if (archetypes is null | archetypes == "" | archetypes.Split('/').Length != 2)
            {
                return "Wrong team archetypes. Must be 2 archetypes!";
            }
            if (operatives_id.Count == 0)
            {
                return "Wrong datacards quantity. Must be min 1 operative's datacard!";
            }

            Team team_to_add = new Team { id = current_kill_teams.Count + 1, Name = name, Rules = rules, Ploys = ploys, Faction_equipment = faction_equip, Archetypes = archetypes, Datacards = operatives_id };
            current_kill_teams.Add(team_to_add);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.SerializeAsync(fs, current_kill_teams, options);
            }

            return $"New team '{name}' succsesfully added";
        }
        static string update_team(JsonSerializerOptions options, string path, List<Team> current_kill_teams, int update_id, string name, string rules, List<Stratagem> ploys, string faction_equip, string archetypes, List<int> operatives_id)
        {
            // проверки на пустые поля
            if (name is null | name == "")
            {
                return "Empty team name";
            }
            if (rules is null | rules == "")
            {
                return "Empty team rules. Min 1 required!";
            }
            if (ploys.Count == 0)
            {
                return "Wrong ploys quantity. Min 1 stratagem required!";
            }
            if (faction_equip is null | faction_equip == "")
            {
                return "Wrong faction equipment. Min 1 faction equipment required!";
            }
            if (archetypes is null | archetypes == "" | archetypes.Split('/').Length != 2)
            {
                return "Wrong team archetypes. Must be 2 archetypes!";
            }
            if (operatives_id.Count == 0)
            {
                return "Wrong datacards quantity. Must be min 1 operative's datacard!";
            }

            Team team_to_update = new Team { id = update_id + 1, Name = name, Rules = rules, Ploys = ploys, Faction_equipment = faction_equip, Archetypes = archetypes, Datacards = operatives_id };

            current_kill_teams[update_id] = team_to_update; // заменяет профиль команды с указанным id

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.SerializeAsync(fs, current_kill_teams, options);
            }

            return $"Team '{name}' succsesfully updated";
        }
        static string delete_team(JsonSerializerOptions options, string path, List<Team> current_kill_teams, int to_delete_id)
        {
            if (to_delete_id < 0 | to_delete_id >= current_kill_teams.Count)
            {
                return "Check ID of team to delete!";
            }

            for (int i = to_delete_id + 1; i < current_kill_teams.Count; i++)
            {
                current_kill_teams[i].id -= 1;
            }
            current_kill_teams.RemoveAt(to_delete_id);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.SerializeAsync(fs, current_kill_teams, options);
            }

            return $"Team with ID {to_delete_id+1} succsesfully deleted";
        }

        static string add_new_operative(JsonSerializerOptions options, string path, List<Operative> current_operatives_list, string team_name, string name, int apl_stat, int m_stat, int sv_stat, int w_stat, List<int> weapons_id, string abilities, List<string> keys)
        {
            if (team_name is null | team_name == "")
            {
                return "Empty team name";
            }
            if (name is null | name == "")
            {
                return "Empty operative's name";
            }
            if (apl_stat < 1)
            {
                return "APL stat can't be less than 1";
            }
            if (m_stat < 1)
            {
                return "Move stat can't be less than 1";
            }
            if (sv_stat < 2 | sv_stat > 7)
            {
                return "Save stat can't be less than 2+ or higher than 7+";
            }
            if (w_stat < 1)
            {
                return "Wounds stat can't be less than 1";
            }
            if (keys.Count == 0)
            {
                return "No keywords. Min 1 required";
            }

            Operative operative_to_add = new Operative { id = current_operatives_list.Count + 1, Team_name = team_name, Name = name, APL = apl_stat, Move = m_stat, Save = sv_stat, Wounds = w_stat, Weapons_id = weapons_id, Abilities = abilities, Keywords = keys };
            current_operatives_list.Add(operative_to_add);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.SerializeAsync(fs, current_operatives_list, options);
            }

            return $"New operative '{name}' succsesfully added";
        }
        static string update_operative(JsonSerializerOptions options, string path, List<Operative> current_operatives_list, int update_id, string team_name, string name, int apl_stat, int m_stat, int sv_stat, int w_stat, List<int> weapons_id, string abilities, List<string> keys)
        {
            if (team_name is null | team_name == "")
            {
                return "Empty team name";
            }
            if (name is null | name == "")
            {
                return "Empty operative's name";
            }
            if (apl_stat < 1)
            {
                return "APL stat can't be less than 1";
            }
            if (m_stat < 1)
            {
                return "Move stat can't be less than 1";
            }
            if (sv_stat < 2 | sv_stat > 7)
            {
                return "Save stat can't be less than 2+ or higher than 7+";
            }
            if (w_stat < 1)
            {
                return "Wounds stat can't be less than 1";
            }
            if (keys.Count == 0)
            {
                return "No keywords. Min 1 required";
            }

            Operative operative_to_update = new Operative
            {
                id = update_id + 1,
                Team_name = team_name,
                Name = name,
                APL = apl_stat,
                Move = m_stat,
                Save = sv_stat,
                Wounds = w_stat,
                Weapons_id = weapons_id,
                Abilities = abilities,
                Keywords = keys
            };

            current_operatives_list[update_id] = operative_to_update; // заменяет профиль оперативника с указанным id

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.SerializeAsync(fs, current_operatives_list, options);
            }

            return $"Operative '{name}' succsesfully updated";
        }
        static string delete_operative(JsonSerializerOptions options, string path, List<Operative> current_operatives_list, int to_delete_id)
        {
            if (to_delete_id < 0 | to_delete_id >= current_operatives_list.Count)
            {
                return "Check ID of operative to delete!";
            }

            for (int i = to_delete_id + 1; i < current_operatives_list.Count; i++)
            {
                current_operatives_list[i].id -= 1;
            }
            current_operatives_list.RemoveAt(to_delete_id);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.SerializeAsync(fs, current_operatives_list, options);
            }

            return $"Operative with ID {to_delete_id + 1} succsesfully deleted";
        }

        static string add_new_weapon(JsonSerializerOptions options, string path, List<Weapon> current_weapons_list, string team_name, string type, string name, int a_stat, int hit_stat, int Nd_stat, int Cd_stat, List<string> rules)
        {
            if (team_name is null | team_name == "")
            {
                return "Empty team name";
            }
            if (name is null | name == "")
            {
                return "Empty weapon name";
            }
            if (type != "Ranged" && type != "Melee")
            {
                return "Wrong weapon type. Must be 'Ranged' or 'Melee'";
            }
            if (a_stat < 1)
            {
                return "Attack stat can't be less than 1";
            }
            if (hit_stat < 2 | hit_stat > 6)
            {
                return "Hit stat can't be less than 2+ and higher than 6+";
            }
            if (Nd_stat < 0)
            {
                return "Normal damage can't be less than 0";
            }
            if (Cd_stat < 0)
            {
                return "Critical damage can't be less than 0";
            }

            Weapon weapon_to_add = new Weapon
            {
                id = current_weapons_list.Count + 1,
                Team_name = team_name,
                Name = name,
                Type = type,
                Attack = a_stat,
                Hit = hit_stat,
                Normal_damage = Nd_stat,
                Critical_damage = Cd_stat,
                Rules = rules
            };
            current_weapons_list.Add(weapon_to_add);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.SerializeAsync(fs, current_weapons_list, options);
            }

            return $"New weapon '{name}' succsesfully added";
        }
        static string update_weapon(JsonSerializerOptions options, string path, List<Weapon> current_weapons_list, int update_id, string team_name, string type, string name, int a_stat, int hit_stat, int Nd_stat, int Cd_stat, List<string> rules)
        {
            if (update_id < 0 | update_id > current_weapons_list.Count)
            {
                return "Check ID of weapon to update!";
            }
            if (team_name is null | team_name == "")
            {
                return "Empty team name";
            }
            if (name is null | name == "")
            {
                return "Empty weapon name";
            }
            if (type != "Ranged" && type != "Melee")
            {
                return "Wrong weapon type. Must be 'Ranged' or 'Melee'";
            }
            if (a_stat < 1)
            {
                return "Attack stat can't be less than 1";
            }
            if (hit_stat < 2 | hit_stat > 6)
            {
                return "Hit stat can't be less than 2+ and higher than 6+";
            }
            if (Nd_stat < 0)
            {
                return "Normal damage can't be less than 0";
            }
            if (Cd_stat < 0)
            {
                return "Critical damage can't be less than 0";
            }

            Weapon weapon_to_update = new Weapon
            {
                id = update_id + 1,
                Team_name = team_name,
                Name = name,
                Type = type,
                Attack = a_stat,
                Hit = hit_stat,
                Normal_damage = Nd_stat,
                Critical_damage = Cd_stat,
                Rules = rules
            };

            current_weapons_list[update_id] = weapon_to_update; // заменяет профиль оружия с указанным id

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.SerializeAsync(fs, current_weapons_list, options);
            }

            return $"Weapon '{name}' succsesfully updated";
        }
        static string delete_weapon(JsonSerializerOptions options, string path, List<Weapon> current_weapons_list, int to_delete_id)
        {
            if (to_delete_id < 0 | to_delete_id >= current_weapons_list.Count)
            {
                return "Check ID of weapon to delete!";
            }

            for (int i = to_delete_id + 1; i < current_weapons_list.Count; i++)
            {
                current_weapons_list[i].id -= 1;
            }
            current_weapons_list.RemoveAt(to_delete_id);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                JsonSerializer.SerializeAsync(fs, current_weapons_list, options);
            }

            return $"Weapon with ID {to_delete_id + 1} succsesfully deleted";
        }


        List<Weapon> current_weapons_list = new List<Weapon> { };
        List<Operative> current_operatives_list = new List<Operative> { };
        List<Team> current_teams_list = new List<Team> { };

        static string selected_operation_type = "";
        static string selected_operation_object = "";
        static string temp_team_rule_to_add = "";
        static List<Stratagem> temp_team_stratagem_to_add = new List<Stratagem> { };
        static string temp_team_equip_to_add = "";
        static List<int> temp_team_oper_id_to_add = new List<int> { };


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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "delete")
            {
                operation_delete_box.Visible = true;
                //operation_add_weapon_box.Visible = false;
                //operation_add_operative_box.Visible = false;
                operation_add_team_box.Visible = false;
                selected_operation_type = "delete";
            }
            if (comboBox1.SelectedItem.ToString() == "add")
            {
                selected_operation_type = "add";
                if (selected_operation_object != "" | selected_operation_object != null)
                {
                    if (selected_operation_object == "Team")
                    {
                        operation_delete_box.Visible = false;
                        //operation_add_weapon_box.Visible = false;
                        //operation_add_operative_box.Visible = false;
                        operation_add_team_box.Visible = true;
                    }
                    if (selected_operation_object == "Operative")
                    {
                        operation_delete_box.Visible = false;
                        //operation_add_weapon_box.Visible = false;
                        //operation_add_operative_box.Visible = true;
                        operation_add_team_box.Visible = false;
                    }
                    if (selected_operation_object == "Weapon")
                    {
                        operation_delete_box.Visible = false;
                        //operation_add_weapon_box.Visible = true;
                        //operation_add_operative_box.Visible = false;
                        operation_add_team_box.Visible = false;
                    }
                }
            }
        }

        private void Team_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            selected_operation_object = "Team";
            if (selected_operation_type == "add")
            {
                operation_delete_box.Visible = false;
                //operation_add_weapon_box.Visible = false;
                //operation_add_operative_box.Visible = false;
                operation_add_team_box.Visible = true;
            }
        }
        private void Operative_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            selected_operation_object = "Operative";
            if (selected_operation_type == "add")
            {
                operation_delete_box.Visible = false;
                //operation_add_weapon_box.Visible = false;
                //operation_add_operative_box.Visible = true;
                operation_add_team_box.Visible = false;
            }
        }
        private void Weapon_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            selected_operation_object = "Weapon";
            if (selected_operation_type == "add")
            {
                operation_delete_box.Visible = false;
                //operation_add_weapon_box.Visible = true;
                //operation_add_operative_box.Visible = false;
                operation_add_team_box.Visible = false;
            }
        }

        private void apply_button_Click(object sender, EventArgs e)
        {
            Output_result.Text = "Result of operation";
            bool availability_operation_base_data = false;
            if (selected_operation_type == "" | selected_operation_type == null)
            {
                Output_result.Text = "Choose type of operation";
            }
            else
            {
                if (selected_operation_object == "" | selected_operation_object == null) 
                {
                    Output_result.Text = "Choose object of operation";
                }
                else
                {
                    availability_operation_base_data = true;
                }
            }
            
            if (availability_operation_base_data)
            {
                if (selected_operation_type == "delete")
                {
                    try
                    {
                        int to_delete_id = Int32.Parse(delete_operation_field_ID.Text);
                        string result = "";
                        if (selected_operation_object == "Team")
                        {
                            result = delete_team(options, dir_name + "kill_teams.json", current_teams_list, to_delete_id-1);
                            listBox_Teams.Items.Clear();
                            foreach (Team ct in current_teams_list)
                            {
                                listBox_Teams.Items.Insert(ct.id - 1, ct.id.ToString() + ": " + ct.Name);
                            }
                        }
                        if (selected_operation_object == "Operative")
                        {
                            result = delete_operative(options, dir_name + "operatives.json", current_operatives_list, to_delete_id - 1);
                            listBox_Operatives.Items.Clear();
                            foreach (Operative ct in current_operatives_list)
                            {
                                listBox_Operatives.Items.Insert(ct.id - 1, ct.id.ToString() + ": " + ct.Name);
                            }
                        }
                        if (selected_operation_object == "Weapon")
                        {
                            result = delete_weapon(options, dir_name + "weapons.json", current_weapons_list, to_delete_id - 1);
                            listBox_Weapons.Items.Clear();
                            foreach (Weapon ct in current_weapons_list)
                            {
                                listBox_Weapons.Items.Insert(ct.id - 1, ct.id.ToString() + ": " + ct.Name);
                            }
                        }
                        Output_result.Text = result;
                    }
                    catch
                    {
                        Output_result.Text = "Error. Check values in the fields.";
                    }
                }
                if (selected_operation_type == "add")
                {
                    try
                    {
                        string result = "";
                        if (selected_operation_object == "Team")
                        {
                            string name = add_team_operation_field_name.Text;

                            string team_rules = temp_team_rule_to_add;
                            temp_team_rule_to_add = "";

                            List<Stratagem> team_stratagems = temp_team_stratagem_to_add;
                            temp_team_stratagem_to_add = new List<Stratagem> { };

                            string team_equip = temp_team_equip_to_add;
                            temp_team_equip_to_add = "";

                            string team_arch = add_team_operation_field_archetypes1.Text + " / " + add_team_operation_field_archetypes2.Text;

                            List<int> team_opers = temp_team_oper_id_to_add;
                            temp_team_oper_id_to_add = new List<int> { };

                            bool team_already_added = false;
                            bool team_already_updated = false;
                            int team_to_update_id = 0;
                            foreach (Team tt in current_teams_list)
                            {
                                if (tt.Name == name)
                                {
                                    team_already_added = true;
                                    if (tt.Rules == team_rules && tt.Ploys == team_stratagems && tt.Faction_equipment == team_equip && tt.Archetypes == team_arch && tt.Datacards == team_opers)
                                    {
                                        team_already_updated = true;
                                    }
                                    else { team_to_update_id = tt.id - 1; }
                                    break;
                                }
                            }

                            if (team_already_added)
                            {
                                if (team_already_updated) { Console.WriteLine("No changes, operation canceled."); }
                                else
                                {
                                    result = update_team(options, dir_name + "kill_teams.json", current_teams_list, team_to_update_id, name, team_rules, team_stratagems, team_equip, team_arch, team_opers);
                                }
                            }
                            else
                            {
                                result = add_new_team(options, dir_name + "kill_teams.json", current_teams_list, name, team_rules, team_stratagems, team_equip, team_arch, team_opers);
                            }

                            listBox_Teams.Items.Clear();
                            foreach (Team ct in current_teams_list)
                            {
                                listBox_Teams.Items.Insert(ct.id - 1, ct.id.ToString() + ": " + ct.Name);
                            }
                        }
                        if (selected_operation_object == "Operative")
                        {
                        }
                        if (selected_operation_object == "Weapon")
                        {
                        }
                        Output_result.Text = result;
                    }
                    catch
                    {
                        Output_result.Text = "Error. Check values in the fields.";
                    }
                }
            }

        }

        private void add_team_operation_rule_add_button_Click(object sender, EventArgs e)
        {
            if (add_team_operation_field_rule_name.Text != "" && add_team_operation_field_rule_name.Text != null && add_team_operation_field_rule_content.Text != "" && add_team_operation_field_rule_content.Text != null)
            {
                if (temp_team_rule_to_add != "")
                {
                    temp_team_rule_to_add += "?";
                }
                temp_team_rule_to_add += add_team_operation_field_rule_name.Text + "!" + add_team_operation_field_rule_content.Text;
                add_team_operation_output_label.Text = $"New rule {add_team_operation_field_rule_name.Text} successfully added.";
            }
            else
            {
                add_team_operation_output_label.Text = "Error to adding new rule. Empty fields.";
            }
        }

        private void add_team_operation_ploy_add_button_Click(object sender, EventArgs e)
        {
            if (add_team_operation_field_ploy_name.Text != "" && add_team_operation_field_ploy_name.Text != null && add_team_operation_field_ploy_content.Text != "" && add_team_operation_field_ploy_content.Text != null && add_team_operation_box_ploy_type.SelectedItem.ToString() != "" && add_team_operation_box_ploy_type.SelectedItem.ToString() != null)
            {
                string ploy_type = "";
                string ploy_name = "";
                string ploy_cont = "";
                if (add_team_operation_box_ploy_type.SelectedItem.ToString() == "Strategy ploy")
                {
                    ploy_type = "Strategy ploy";
                }
                if (add_team_operation_box_ploy_type.SelectedItem.ToString() == "Firefight ploy")
                {
                    ploy_type = "Firefight ploy";
                }
                ploy_name = add_team_operation_field_ploy_name.Text;
                ploy_cont = add_team_operation_field_ploy_content.Text;
                temp_team_stratagem_to_add.Add(new Stratagem { Type = ploy_type, Name = ploy_name, Content = ploy_cont});
                add_team_operation_output_label.Text = $"New ploy {ploy_type}-{ploy_name} successfully added.";
            }
            else
            {
                add_team_operation_output_label.Text = "Error to adding new ploy. Empty fields.";
            }
        }

        private void add_team_operation_equip_add_button_Click(object sender, EventArgs e)
        {
            if (add_team_operation_field_equip_name.Text != "" && add_team_operation_field_equip_name.Text != null && add_team_operation_field_equip_content.Text != "" && add_team_operation_field_equip_content.Text != null)
            {
                if (temp_team_equip_to_add != "")
                {
                    temp_team_equip_to_add += "?";
                }
                temp_team_equip_to_add += add_team_operation_field_equip_name.Text + "!" + add_team_operation_field_equip_content.Text;
                add_team_operation_output_label.Text = $"New equipment {add_team_operation_field_equip_name.Text} successfully added.";
            }
            else
            {
                add_team_operation_output_label.Text = "Error to adding new equipment. Empty fields.";
            }
        }

        private void add_team_operation_header_archetypes_Click(object sender, EventArgs e)
        {

        }

        private void add_team_operation_field_archetypes1_TextChanged(object sender, EventArgs e)
        {

        }

        private void add_team_operation_field_archetypes2_TextChanged(object sender, EventArgs e)
        {

        }

        private void add_team_operation_oper_add_button_Click(object sender, EventArgs e)
        {
            if (add_team_operation_field_oper_id.Text != "" && add_team_operation_field_oper_id.Text != null)
            {
                List<int> operatives_id_list = new List<int> { };
                foreach (Operative t in current_operatives_list)
                {
                    operatives_id_list.Add(t.id);
                }

                int op_id_to_add = Int32.Parse(add_team_operation_field_oper_id.Text);
                if (!operatives_id_list.Contains(op_id_to_add))
                {
                    add_team_operation_output_label.Text = "Error! Operatives with this ID doesn't exist!";
                }
                else
                {
                    temp_team_oper_id_to_add.Add(op_id_to_add);
                    add_team_operation_output_label.Text = $"New operative with ID {op_id_to_add} successfully added.";
                }                    
            }
            else
            {
                add_team_operation_output_label.Text = "Error to adding new operative. Empty field.";
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
