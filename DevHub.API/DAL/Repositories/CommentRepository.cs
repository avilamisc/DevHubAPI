using DevHub.API.DAL.Interfaces;
using DevHub.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevHub.API.DAL.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DevHubContext context) : base(context)
        {
        }
    }
}