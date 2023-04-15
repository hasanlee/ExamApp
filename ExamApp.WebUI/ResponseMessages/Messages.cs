namespace ExamApp.WebUI.ResponseMessages
{
    public static class Messages
    {
        public static string Add(string title)
        {
            return $"{title} added!";
        }

        public static string Update(string title)
        {
            return $"{title} updated!";
        }
        public static string Delete(string title)
        {
            return $"{title} deleted!";
        }
    }
}
