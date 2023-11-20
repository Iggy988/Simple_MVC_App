namespace WebApp.Models;

//static repository
public class CategoriesRepository
{
    private static List<Category> _categories = new List<Category>()
    {
        new Category{CategoryId = 1, Name ="Beverage", Description= "Beverage"},
        new Category{CategoryId = 2, Name ="Bakery", Description= "Bakery"},
        new Category{CategoryId = 3, Name ="Meat", Description= "Meat"},
    };

    public void AddCaategory(Category category)
    {
        var maxId = _categories.Max(c => c.CategoryId);
        category.CategoryId = maxId + 1;
        _categories.Add(category);
    }

    public static List<Category> GetCategories() 
    { 
        return _categories; 
    }

    public static Category? GetCategoryById(int categoryId)
    {
        var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
        if (categoryId != null)
        {
            //a ko nije nul kreiramo kopiju i vracamo je
            // user ne treba da ima dodira sa db
            return new Category 
            { 
                CategoryId = category.CategoryId,
                Name = category.Name, 
                Description = category.Description
            };
        }
        return null;
    }

    public static void UpdateCategory(int categoryId, Category category) 
    {
        if (categoryId != category.CategoryId)
        {
            return;
        }
        var categoryToUpdate = GetCategoryById(categoryId);
        if (categoryToUpdate != null)
        {
            //ovdje mozemo koristiti auto mapper
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = category.Description;
        }
    }

    public static void DeleteCategory(int categoryId)
    {
        var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
        if (category != null)
        {
            _categories.Remove(category);
        }
    }
}
