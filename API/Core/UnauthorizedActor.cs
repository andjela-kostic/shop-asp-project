using Application;


namespace API.Core
{
    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 0;
        public string Identity => "Unauthorized user";
        public IEnumerable<int> AllowedUseCases =>
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
    }
}
