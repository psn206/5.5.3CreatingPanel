using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CreatingPanel
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
           return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {

            string TabName = "Панель плагинов";
            application.CreateRibbonTab(TabName);
            string utilsFolderPatch = @"C:\Program Files\RevitAPI\";
            var panel = application.CreateRibbonPanel(TabName, "Приложения");

            var buttonSystem = new PushButtonData("Система", "Смена ситстемы труб",
                Path.Combine(utilsFolderPatch, "CreatingButtons.dll"),
                "CreatingButtons.Main");

            Uri imageButtonSystem = new Uri(@"C:\Program Files\RevitAPI\Image\Трубы.png", UriKind.Absolute);
            BitmapImage mapImageSystem = new BitmapImage(imageButtonSystem);
            buttonSystem.LargeImage = mapImageSystem;

            var buttonType = new PushButtonData("Типы", "Смена типа стен",
               Path.Combine(utilsFolderPatch, "ChangingWallTypes.dll"),
               "ChangingWallTypes.Main");

            Uri imageButtonType = new Uri(@"C:\Program Files\RevitAPI\Image\Стены.png", UriKind.Absolute);
            BitmapImage mapImageType = new BitmapImage(imageButtonType);
            buttonType.LargeImage = mapImageType;

            panel.AddItem(buttonSystem);
            panel.AddItem(buttonType);

            return Result.Succeeded;
        }
    }
}
