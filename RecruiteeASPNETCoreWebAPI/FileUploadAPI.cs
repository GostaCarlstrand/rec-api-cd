using System;
namespace ASPNETCoreWebAPI
{
    public class FileUploadAPI
    {
        
        public string? name { get; set; }
        public string? emails { get; set; }
        public string? phones { get; set; }
        public string? social_links { get; set; }
        public string? links { get; set; }
        public string? cover_letter { get; set; }
        public string? company_id { get; set; }
        public IFormFile? files { get; set; }
        
    }
    public class common
    {
        public FileUploadAPI? _fileAPI { get; set; }
        public Customer? _Customer { get; set; }
        public List<Customer>? LstCustomer { get; set; }
    }
}

