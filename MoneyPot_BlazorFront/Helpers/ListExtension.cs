namespace MoneyPot_BlazorFront.Helpers
{
    public static class ListExtension
    {
        /// <summary>
        /// Add an element in the list if he doesn't exists
        /// Update the element otherwise
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="elem"></param>
        public static void AddOrUpdate<T>(this IList<T> list, T elem) where T : class, new()
        {
            if(list == null) list = new List<T>();

            if (!list.Any(x => x.Equals(elem)))
                list.Add(elem);
            else
            {
                var x = list.First(x => x.Equals(elem));
                x = elem;
            }
        }
    }
}
