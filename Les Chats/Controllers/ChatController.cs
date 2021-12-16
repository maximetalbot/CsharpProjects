using Les_Chats.Models;
using Microsoft.AspNetCore.Mvc;

namespace Les_Chats.Controllers
{
    public class ChatController : Controller
    {
        // GET: ChatController
        public ActionResult Index()
        {
            var chats = Chat.GetMeuteDeChats();
            return View(chats);
        }

        // GET: ChatController/Details/5
        public ActionResult Details(int id)
        {
            var chats = Chat.GetMeuteDeChats();
            var chat = chats.Find(x => x.Id == id);
            return View(chat);
        }

        // GET: ChatController/Delete/5
        public ActionResult Delete(int id)
        {
            var chats = Chat.GetMeuteDeChats();
            var chat = chats.Find(x => x.Id == id);
            return View(chat);
        }

        // POST: ChatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
