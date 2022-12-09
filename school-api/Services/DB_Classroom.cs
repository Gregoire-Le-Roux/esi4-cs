namespace school_api.Services
{
    public class DB_Classroom
    {
        private ApplicationDbContext _context { init; get; }


        public DB_Classroom(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
        }

        public IQueryable GetClassroomsService()
        {
            var classrooms =
                     from a in _context.Classrooms
                     select new { a.Id, a.Name };
            return classrooms;
        }
    }
}
