using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        void MessageAdd(Message message);
        Message GetById(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        List<Message> GetReadList(string p);
        List<Message> GetUnReadList(string p);
        List<Message> GetListDraft(string p);
        List<Message> GetListTrash(string p);

        //
        List<Message> GetMessagesInbox();
        List<Message> GetMessageSendBox();
        List<Message> GetAllRead();
        List<Message> IsDraft();

    }
}
