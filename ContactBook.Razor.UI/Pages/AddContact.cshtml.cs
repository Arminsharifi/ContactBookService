using ContactBook.Razor.UI.BLL;
using ContactBook.Razor.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactBook.Razor.UI.Pages
{
    public class AddContactModel : PageModel
    {
        public Contact contact = new Contact();

        public void OnGet()
        {
        }

        public IActionResult OnPost(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if(new ContactBLL().Add(contact)) return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
