namespace EmployeeManagement.Web.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;
        protected string Name { get; set; } = "Tom";

        protected string Colour { get; set; } = "background-color:white";
        private void IncrementCount()
        {
            currentCount++;
        }
    }
}
