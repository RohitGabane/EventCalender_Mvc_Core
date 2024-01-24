using System.ComponentModel.DataAnnotations;

namespace EventCalender.Models
{
    public class Event
    {
        [Key]
        public int EventID {  get; set; }
        public string? Subject {  get; set; }
        public string? Description {  get; set; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public string? ThemeColor {  get; set; }
        public bool IsFullDay { get; set; }
    }
}
