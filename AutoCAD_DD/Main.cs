﻿using System;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.Windows;
using System.Windows.Media.Imaging;
using Autodesk.AutoCAD.Runtime;
using System.Windows.Forms;

using acadApp = Autodesk.AutoCAD.ApplicationServices.Application;


namespace SectionConverterPlugin
{
    public class MainExtensionApplication : IExtensionApplication
    {
        /// <summary>
        /// Функция инициализации (выполняется при загрузке плагина)
        /// </summary>
        public void Initialize()
        {
            acadApp.Idle += StartPluginHandler;
        }

        private void StartPluginHandler(object sender, EventArgs e)
        {
            var document = Autodesk.AutoCAD.ApplicationServices
               .Application.DocumentManager.MdiActiveDocument;

            acadApp.Idle -= StartPluginHandler;

            new BuildRibbonItem().CreateRibbonTab();
            new AcadTools().CreateLayersForPluginTool(document);
        }

        /// <summary>
        /// Функция, выполняемая при выгрузке плагина
        /// </summary>
        public void Terminate()
        {
            MessageBox.Show("Goodbye!");
        }
    }
}