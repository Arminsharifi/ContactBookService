using ContactBook.Razor.UI.BLL;
using ContactBook.Razor.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactBook.Razor.UI.Pages
{
    public class IndexModel : PageModel
    {
        public List<Contact> lstContacts = new List<Contact>();

        public void OnGet()
        {
            lstContacts = new ContactBLL().GetAll();
        }

        public RedirectToPageResult OnGetDelete(int Id)
        {
            new ContactBLL().Delete(Id);
            return RedirectToPage("Index");
        }
        
        public RedirectToPageResult OnGetUpdate(int Id)
        {
            return RedirectToPage("Index");
        }
    }
}