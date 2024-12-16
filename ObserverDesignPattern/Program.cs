public class Program
{
    public static void Main()
    {
        JobPostings jobPostings = new JobPostings();
        JobSeeker Pradnya = new JobSeeker("Pradnya");
        JobSeeker Anurag = new JobSeeker("Anurag");
        JobSeeker Kumar = new JobSeeker("Kumar");
        JobSeeker Anup = new JobSeeker("Anup");

        //Attach
        jobPostings.Attach(Pradnya);
        jobPostings.Attach(Anurag);
        jobPostings.Attach(Kumar);
        jobPostings.Attach(Anup);

        //Detach
        jobPostings.Detach(Anurag);

        //Add post
        jobPostings.AddJob(new Job("Software Developer at Pepcus"));
        Console.ReadKey();
    }
}

// Observer Interface
public interface IJobSeeker
{
    void Notify(Job job);
}


// Concrete Observer
public class JobSeeker : IJobSeeker
{
    public string Name { get; set; }
    public JobSeeker(string name)
    {
        Name = name;
    }
    public void Notify(Job job)
    {
        Console.WriteLine($"Hi {Name}, new job posted: {job.Description}");
    }
}


// Subject Interface
public interface IJobPostings
{
    void Attach(IJobSeeker jobSeeker);
    void Detach(IJobSeeker jobSeeker);
    void Notify(Job job);
}


// Concrete Subject maintains a list of all the JobSeeker (Observer) instances interested in job notifications.
// Whenever a new job is added using the AddJob method, all registered job seekers are notified about the job posting.
public class JobPostings : IJobPostings
{
    private List<IJobSeeker> _jobSeekers = new List<IJobSeeker>();
    public void Attach(IJobSeeker jobSeeker)
    {
        _jobSeekers.Add(jobSeeker);
    }
    public void Detach(IJobSeeker jobSeeker)
    {
        _jobSeekers.Remove(jobSeeker);
    }
    public void Notify(Job job)
    {
        foreach (var jobSeeker in _jobSeekers)
        {
            jobSeeker.Notify(job);
        }
    }
    public void AddJob(Job job)
    {
        Notify(job);
    }
}

public class Job
{
    public string Description { get; set; }
    public Job(string description)
    {
        Description = description;
    }
}

//In the example above:

//JobPostings(Subject) maintains a list of all the JobSeeker (Observer) instances interested in job notifications.
//Whenever a new job is added using the AddJob method, all registered job seekers are notified about the job posting.
//When you run the Main method, “Pranaya”, “Kumar”, and “Rout” are notified about the “Software Developer at Microsoft” job posting.