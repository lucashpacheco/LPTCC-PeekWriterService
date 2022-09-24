using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeekWriterService.Models.Domain;

namespace PeekWriterService.Service.Interfaces
{
    public interface ILikesRepository
    {
        Task<bool> Save(LikesDocument commentsDocument);
        Task<bool> Update(LikesDocument commentsDocument);
        Task<bool> Delete(Guid? id);
    }
}
