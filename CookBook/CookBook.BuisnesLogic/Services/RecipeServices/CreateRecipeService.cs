using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using Database;
using Database.Entities;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;




namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    public class CreateRecipeService : ICreateRecipeService
    {
        private readonly IAzureStorage _azureStorage;
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IGetUserService _getUserService;

        public CreateRecipeService(IAzureStorage azureStorage,DatabaseContext dbContext, IMapper mapper, IGetUserService userService)
        {
            _azureStorage = azureStorage;
            _dbContext = dbContext;
            _mapper = mapper;
            _getUserService = userService;
        }

        public async Task CreateRecipe(RecipeDetailsDTO recipe)
        {
            var recipeToAdd = _mapper.Map<RecipeDetails>(recipe);

            recipeToAdd.UserCookBookId = await _getUserService.LoggedUserIdAsync();
            recipeToAdd.AddDate = DateTime.Now;
            recipeToAdd.ImagePath = $"{_azureStorage.BlobContainerClientRecipeFiles.Uri}/null.jpg";

            await _dbContext.RecipeDetails.AddAsync(recipeToAdd);
            _dbContext.SaveChanges();
        }
    }
}
