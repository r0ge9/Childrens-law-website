namespace Diplom.Service
{
    public static class Extensions
    {
        public static string CutController(this string str)
        {
            return str.Replace("Controller", "");
        }
        public static string MonthConverter(int month)
        {
            Dictionary<int, string> months = new Dictionary<int, string>()
            {
                   {1,"Январь" },
                   {2,"Февраль"},
                   {3,"Март"},
                   {4,"Апрель"},
                   {5,"Май"},
                   {6,"Июнь"},
                   {7,"Июль"},
                   {8,"Август"},
                   {9,"Сентябрь"},
                   {10,"Октябрь"},
                   {11,"Ноябрь"},
                   {12,"Декабрь"}
            };
            return months[month];
        }
        public static string[] GetSexes() 
        {
            string[] sexes = { "Отец", "Мать" };
            return sexes;
        }
    }
}

