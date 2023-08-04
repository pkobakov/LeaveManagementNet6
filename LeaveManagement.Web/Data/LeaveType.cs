namespace LeaveManagement.Web.Data
{
    public class LeaveType : BaseIdentity
    {
        
        public string Name { get; set; }
        public int DefaultDays { get; set; }
       
    }
}
