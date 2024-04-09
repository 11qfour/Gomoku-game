using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    class Rules
    {
        private string[] PagesRules;
        private int pages;
        private Image[] Images;

        public void SetPages(int cntpages)
        {
            pages = cntpages;
        }

        public int GetPages()
        {
            return pages;
        }

        //использовать в цикле по индексу и тексту, мб считывать из файла
        public void SetPagesRules(int numpage, string Text) //номер страницы, текст страницы
        {
            PagesRules[numpage] = Text;
        }

        public string GetPagesRules(int numpage) //номер страницы
        {
            return PagesRules[numpage];
        }

        public Rules(int numspages)
        {
            this.pages = numspages;
            this.PagesRules = new string[this.pages];
            this.Images = new Image[this.pages];
        }
    }
}
