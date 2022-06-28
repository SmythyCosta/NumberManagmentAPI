namespace NumberManagmentAPI.DTO
{
    public class CategoryDTO
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool Active { get; set; }


        public CategoryDTO(
            int CategoryId, string CategoryName,
            string CategoryDescription, bool Active)
        {
            this.CategoryId = CategoryId;
            this.CategoryName = CategoryName;
            this.CategoryDescription = CategoryDescription;
            this.Active = Active;
        }

        public CategoryDTO() { }
    }
}
