namespace BlazorApp1.Models
{
    public class Income
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public int Amount { get; set; }
        public enum Type {
            Salary,
            Scholarship,
            Gift,
            LuckyWinnings
        };
    }
}
