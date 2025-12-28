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
        public required string Keywords {get; set;}  // Список ключевых слов оперативника
        public required byte base_mm {get; set;}  // Размер базы в миллиметрах оперативника
    }

    class Weapon
    {
        public required string Team_name {get; set;}  // К какой команде относится. !!!НЕ ВЫВОДИТЬ!!!
        public required string Model_name {get; set;}  // Какие модели могут носить. !!!НЕ ВЫВОДИТЬ!!!
        public required string Type {get; set;}  // Тип оружия. Значения м.б. только: "Ranged"/"Melee"
        public required string Name {get; set;}  // Название оружия
        public required byte Atack {get; set;}  // Показатель атаки оружия
        public required byte Hit {get; set;}  // Показатель попадания оружия
        public required byte Normal_damage {get; set;}  // Показатель нормального урона оружия
        public required byte Critical_damage {get; set;}  // Показатель критического урона оружия
        public required List<string> Rules {get; set;}  // Дополнительные правила оружия оружия
    }
    

    class Start
    {
        static string add_new_team(string name, string rules, Operative_selection_rules oper_selection, List<Stratagem> ploys, string faction_equip, string arhetypes, List<string> operatives_data)
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
            if (operatives_data.Count == 0)
            {
                return "Wrong datacards quantity. Must be min 1 operative's datacard!";
            }
            return $"New team '{name}' succsesfully added";
        }

        static void Main() {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,  // Включаем красивое форматирование
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull  // Игнорируем null значения
            };

            /*Console.WriteLine(add_new_team("Deathwatch", "None", new Operative_selection_rules {quantity=5, operatives = new List<string>() { "Tom", "Bob", "Sam" }, Limits="None"}, 
            new List<Stratagem>() {new Stratagem {Type="Strategy ploy", Name="None", Content="None"}}, "None", "None", new List<string>() {}));*/
        }
    }
}