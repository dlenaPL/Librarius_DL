namespace Librarius_DL.Utilities
{
    public class BookCopiesForView
    {
        public int BookCopyID { get; set; }
        public string BookTitle { get; set; }
        public byte[] QRCode { get; set; }
        public string CopyStatus { get; set; }
        public string CopyCondition { get; set; }
    }
}
