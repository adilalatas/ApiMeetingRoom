namespace Entitiyes.RequestFeatures
{
    public class MeetingParameters:RequestParameters 
	{
     
        public String? SearchTerm { get; set; }

        public MeetingParameters()
        {
            OrderBy = "CreateDate";
        }
    }
}
