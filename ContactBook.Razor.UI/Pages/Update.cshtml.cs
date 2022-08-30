using ContactBook.Razor.UI.BLL;
using ContactBook.Razor.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactBook.Razor.UI.Pages
{
    public class UpdateModel : PageModel
    {
        public Contact contact = new Contact();
        private static Contact Savedcontact = new Contact();

        public void OnGet(int Id)
        {
            contact = new ContactBLL().Get(Id);
            Savedcontact = contact;
        }

        public IActionResult OnPost(Contact contact)
        {
            contact.Id = Savedcontact.Id;
            if (ModelState.IsValid)
            {
                if (new ContactBLL().Update(contact)) return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
