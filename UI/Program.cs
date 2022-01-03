
UIRepo repo = new UserRepo();

UserBL bl = new UserBL(repo);

MenuLogin menu = new MenuLogin(bl);
// starting program at the menu
menu.Start();