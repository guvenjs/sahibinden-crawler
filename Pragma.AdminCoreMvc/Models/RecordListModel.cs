namespace Pragma.AdminCoreMvc.Models
{
    public class RecordListModel
    {
        public int Id { get; set; }
        public string ThumbnailImage { get; set; }
        public string Brand { get; set; }
        public string Serie { get; set; }
        public string Year { get; set; }
        public string KM { get; set; }
        public int LivePrice { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public string DateCreated { get; set; }
    }
}
