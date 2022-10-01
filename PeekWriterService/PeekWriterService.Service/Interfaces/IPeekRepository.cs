using System;
using System.Threading.Tasks;
using Peek.Framework.PeekServices.Documents;

namespace PeekWriterService.Service.Interfaces
{
    public interface IPeekRepository
    {
        Task<bool> Save(PeekDocument commentsDocument);
        Task<bool> Update(PeekDocument commentsDocument);
        Task<bool> Delete(Guid? id);
    }
}
