using System;
using System.Threading.Tasks;
using PeekWriterService.Models.Domain;

namespace PeekWriterService.Service.Interfaces
{
    public interface IPeekRepository
    {
        Task<bool> Save(PeekDocument commentsDocument);
        Task<bool> Update(PeekDocument commentsDocument);
        Task<bool> Delete(Guid? id);
    }
}
