using System.Text.Json;

namespace Programm
{
    class Stratagem //содержит данные о стратагемах
    {
        public required string Type {get; set;}  // содержит тип стратагемы "Strategy ploy"/"Firefight ploy"
        public required string Name {get; set;}  // содержит название стратагемы
        public required string Content {get; set;}  // содержит описание действий стратагемы
    }

    class Operative_selection_rules
    {
        public required byte quantity {get; set;}  // указывает максимальное число оперативников в команде
        public required string Rules {get; set;}  // содержит правила по выбору оперативников
        public required List<string> operatives {get; set;} // содержит названия и вооружения моделей. Данные записываются в формате: "модель (вооружение)!модель2 (вооружение2)!..."
        public required string Limits {get; set;}  // содержит ограничения по выбору определённых оперативников
    }

    class Team //содержит данные о игровой команде
    {
        public required string Name {get; set;}  // содержит название команды
        public required string Rules {get; set;}  // содержит правила команды. Данные записываются в формате: "название-содержание!название2-содержание2!..."
        public required Operative_selection_rules Operative_selection {get; set;} // содержит правила формирования отряда
        public required List<Stratagem> Ploys {get; set;} // содержит стратагемы
        public required string Faction_equipment {get; set;} // содержит фракционное снаряжение. Данные записываются в формате: "название-содержание!название2-содержание2!..."
        public required string Archetypes {get; set;} // содержит архетипы команд для выбора миссий. Данные записываются в формате: "архетип1!архетип2"
        public required List<string> Datacards {get; set;} // содержит имена моделей, относящихся к данной команде
    }

    class Operative
    {
        public required string Team_name {get; set;}  // К какой команде относится. !!!НЕ ВЫВОДИТЬ!!!
        public required string Name {get; set;}  // Имя оперативника
        public required byte APL {get; set;}  // APL стат оперативника
        public required byte Move {get; set;}  // Move стат оперативника
        public required byte Save {get; set;}  // Save стат оперативника
        public required byte Wounds {get; set;}  // Показатель здоровья оперативника
        public required List<string> Weapons {get; set;}  // Список названий оружия
        public required string Abilities {get; set;}  // Список способностей оперативника
        public required List<string> Keywords {get; set;}  // Список ключевых слов оперативника
    }

    class Weapon
    {
        public required string Team_name {get; set;}  // К какой команде относится. !!!НЕ ВЫВОДИТЬ!!!
        public required string Type {get; set;}  // Тип оружия. Значения м.б. только: "Ranged"/"Melee"
        public required string Name {get; set;}  // Название оружия
        public required byte attack {get; set;}  // Показатель атаки оружия
        public required byte Hit {get; set;}  // Показатель попадания оружия
        public required byte Normal_damage {get; set;}  // Показатель нормального урона оружия
        public required byte Critical_damage {get; set;}  // Показатель критического урона оружия
        public required List<string> Rules {get; set;}  // Дополнительные правила оружия оружия
    }
    

    class Start
    {
        static string add_new_team(JsonSerializerOptions options, string name, string rules, Operative_selection_rules oper_selection, List<Stratagem> ploys, string faction_equip, string arhetypes, List<string> operatives_names)
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
            if (oper_selection.quantity < 1 | oper_selection.operatives.Count == 0)
            {
                return "Wrong operatives quantity. Min 1 required!";
            }
            if (ploys.Count == 0)
            {
                return "Wrong ploys quantity. Min 1 stratagem required!";
            }
            if (faction_equip is null | faction_equip == "")
            {
                return "Wrong faction equipment. Min 1 faction equipment required!";
            }
            if (arhetypes is null | arhetypes == "" | arhetypes.Split('!').Length != 2)
            {
                return "Wrong team archetypes. Must be 2 archetypes!";
            }
            if (operatives_names.Count == 0)
            {
                return "Wrong datacards quantity. Must be min 1 operative's datacard!";
            }
            /*using (FileStream fs = new FileStream("info/kill_teams.json", FileMode.OpenOrCreate))
            {
                Team new_team = new Team { Name = name, Rules = rules, Operative_selection = oper_selection, Ploys = ploys, Faction_equipment = faction_equip, Archetypes = arhetypes, Datacards = operatives_data};
                JsonSerializer.SerializeAsync(fs, new_team, options);
            }*/
            return $"New team '{name}' succsesfully added";
        }

        static string add_new_operative(JsonSerializerOptions options, string team_name, string name, byte apl_stat, byte m_stat, byte sv_stat, byte w_stat, List<string> weapons_names, string abilities, List<string> keys)
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
            return $"New operative '{name}' succsesfully added";
        }

        static string add_new_weapon(JsonSerializerOptions options, string team_name, string type, string name, byte a_stat, byte hit_stat, byte Nd_stat, byte Cd_stat, List<string> Rules)
        {
            if (team_name is null | team_name == "")
            {
                return "Empty team name";
            }
            if (name is null | name == "")
            {
                return "Empty weapon name";
            }
            if (type != "Ranged" | type != "Melee")
            {
                return "Wrong weapon type. Must be Ranged or Melee";
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
                return "Normal damage can't be less than 0";
            }
            return $"New weapon '{name}' succsesfully added";
        }

        static string add_team_rule_or_equip(string s, string name, string content)
        {
            if (s == "")
            {
                return name + "-" + content;
            }
            return s + "!" + name + "-" + content;
        }

        static void TRASH_models_adding()
        {
            Console.WriteLine("Введите количество листов оперативников:");
            int n = int.Parse(Console.ReadLine());

        }

        static void Main() {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,  // Включаем красивое форматирование
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull  // Игнорируем null значения
            };

            /*Console.WriteLine(add_new_team(options, "Deathwatch", "None", new Operative_selection_rules {quantity=5, operatives = new List<string>() { "Tom", "Bob", "Sam" }, Limits="None"}, 
            new List<Stratagem>() {new Stratagem {Type="Strategy ploy", Name="None", Content="None"}}, "None", "Seek!Security", new List<string>() {"Deathwatch gunner veteran"}));*/
            
            //Здесь указываются переменные, в которые будут подставляться значения из полей ввода в WF
            /*string team_name = "Deathwatch";
            string rules = add_team_rule_or_equip(add_team_rule_or_equip("", "Veteran Astartes", "During each friendly DEATHWATCH operative’s activation, it can perform either two Shoot actions or two Fight actions. If it’s two Shoot actions and an auxiliary grenade launcher, frag cannon, heavy plasma incinerator, infernus heavy bolter, plasma pistol or stalker bolt rifle is selected for both, 1 additional AP must be spent for the second action. Each friendly DEATHWATCH operative can counteract regardless of its order. Whenever it does, it can perform an additional 1AP action for free during that counteraction, but both actions must be different."), "Special Issue Ammunition", "Once per turning point, when a friendly DEATHWATCH operative is performing the Shoot action, in the Select Weapon step, you can use this rule. If you do, select one of the following weapon rules for that operative’s ranged weapons to have until the end of the action. This rule cannot be used with explosive grenades (see universal equipment) or melta bombs.\nBlast 1 (you cannot select this if the weapon profile being used has the Torrent weapon rule)\nDevastating 1\nLethal 5+\nPiercing 1\nRending\nSaturate\nSevere");
            byte op_sel_quantity = 5;
            string op_sel_rules = "5 DEATHWATCH operatives selected from the following list:";
            List<string> op_sel_ops = ["WATCH SERGEANT", "AEGIS", "BLADEMASTER", "BOMBARD", "BREACHER", "DEMOLISHER", "DISRUPTOR", "GUNNER", "HEADTAKER", "HORDE-SLAYER", "MARKSMAN"];
            string op_sel_limits = "Your kill team can only include each operative on this list once, and can only include up to one GRAVIS operative.";
            Operative_selection_rules op_sel_rules_to_team = new Operative_selection_rules {quantity = op_sel_quantity, Rules = op_sel_rules, operatives = op_sel_ops, Limits = op_sel_limits};
            List<Stratagem> team_ploys = [new Stratagem{Type = "Strategy ploy", Name="MISSION TACTICS", Content="Select Conceal or Engage. Whenever a friendly DEATHWATCH operative is shooting against or fighting against an enemy operative that has that order, that friendly operative’s weapons have the Balanced weapon rule."},
            new Stratagem{Type = "Strategy ploy", Name="THE SHIELD THAT SLAYS", Content="Whenever a friendly DEATHWATCH operative is within your opponent’s territory, Normal and Critical Dmg of 4 or more inflicts 1 less damage on it."}, 
            new Stratagem{Type = "Strategy ploy", Name="THE LONG VIGIL", Content="Whenever an operative is shooting a friendly DEATHWATCH operative that’s within your territory, you can re-roll one of your defence dice."}, 
            new Stratagem{Type = "Strategy ploy", Name="AND THEY SHALL KNOW NO FEAR", Content="You can ignore any changes to the stats of friendly DEATHWATCH operatives from being injured (including their weapons’ stats)."}, 
            new Stratagem{Type = "Firefight ploy", Name="SUFFER NOT THE ALIEN", Content="Use this firefight ploy after rolling your attack dice for a friendly DEATHWATCH operative, if it’s shooting against or fighting against an operative that doesn’t have the CHAOS or IMPERIUM keyword. You can re-roll any of your attack dice."}, 
            new Stratagem{Type = "Firefight ploy", Name="ADVANCED AUSPEX SCAN", Content="Use this firefight ploy when a friendly DEATHWATCH operative performs the Shoot action. Until the end of the activation/counteraction, its ranged weapons have the Saturate weapon rule and enemy operatives cannot be obscured."}, 
            new Stratagem{Type = "Firefight ploy", Name="AUSPICATOR TRACKING", Content="Use this firefight ploy when a friendly DEATHWATCH operative is counteracting, before it performs any actions. You can change its order."}, 
            new Stratagem{Type = "Firefight ploy", Name="TRANSHUMAN PHYSIOLOGY", Content="Use this firefight ploy when an operative is shooting a friendly DEATHWATCH operative, in the Roll Defence Dice step. You can retain one of your normal successes as a critical success instead."}, 
            ];
            string team_fact_equip = add_team_rule_or_equip(
                add_team_rule_or_equip(
                    add_team_rule_or_equip(
                        add_team_rule_or_equip(
                            "", "DIGITAL WEAPONS", "Once per turning point, when a friendly DEATHWATCH operative performs the Fight action, at the start of the Roll Attack Dice step, you can use this rule. If you do, inflict 1 damage on the enemy operative in that sequence."
                        ), "SANCTUS-V BIOSCRYER CUFFS", "Once during each friendly DEATHWATCH operative’s activation, before or after it performs an action, if it’s not within control range of enemy operatives, you can use this rule. If you do, select one of the following:\nThat friendly operative regains up to D3 lost wounds.\nRemove any changes to that friendly operative’s APL stat.\nRemove one of the following tokens that friendly operative has (before that token’s activation effects are resolved, if relevant): Neutron Fragment, Poison, Terrorchem."
                    ), "SCRUTAVORE SERVO-THRALL", "Once per turning point, during a friendly DEATHWATCH operative’s activation, you can use this rule. If you do, during that activation, that operative can perform a mission action for 1 less AP.\n\nHaving an enemy operative within its control range doesn’t prevent that friendly operative from performing that mission action. However, in such an instance, after it does so, you and your opponent roll-off. If your opponent wins, you cannot use this equipment for the rest of the battle."
                ), "AMMUNITION RESERVE", "Once per battle, you can use the Special Issue Ammunition faction rule for up to two Shoot actions during one turning point, but you must select different weapon rules for both uses. This takes precedence over the normal Special Issue Ammunition rules.");
            string team_archetypes = "Seek&Destroy!Security";*/
        }
    }
}