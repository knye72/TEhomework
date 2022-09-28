
namespace Lecture.Farming  // deleted the other systems when creating a new class
{
    public interface ISingable // something we can sing about.
        //it applies to an object but doesn't make an object. no public/private. 
        //no constructors(can't instantiate) or accessors. 
    {
        string Name { get; }
        string Sound { get; }

    }
}
