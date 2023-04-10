using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Pragim.Components.ConfirmPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages.EditEmployee
{
    public class EditEmployeeBase : ComponentBase
    {
        public string PageHeader { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        private Employee Employee { get; set; } = new Employee();

        public EditEmployeeModel EditEmployeeModel { get; set; } =new EditEmployeeModel();

        public List<Department> Departments { get; set; } = new List<Department>();
        protected ConfirmBase DeleteConfirmation { get; set; }
        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);

            if (employeeId != 0)
            {
                PageHeader = "Edit Employee";
                Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            }
            else
            {
                PageHeader = "Create Employee";
                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBrith = DateTime.Now,
                    PhotoPath = "images/nophoto.jpg"
                };
            }
            Departments = (await DepartmentService.GetDepartments()).ToList();

            Mapper.Map(Employee, EditEmployeeModel);
        }
        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditEmployeeModel, Employee);

            HttpResponseMessage result = null;

            if (Employee.EmployeeId != 0)
            {
                result = await EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee);
            }
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }

        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
                NavigationManager.NavigateTo("/");  
            }
        }
    }
}
