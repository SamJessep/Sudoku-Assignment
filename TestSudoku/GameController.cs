﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class GameController
    {
        protected IView view;
        public Game game;
        protected SudokuForm form;

        public GameController(IView theView, Game theGame, SudokuForm theForm)
        {
            view = theView;
            game = theGame;
            form = theForm;
        }

        public void Go()
        {
            form.SetController(this);
            //game.ToCSV();
            game.FromCSV("C:\\Users\\Sam\\source\\repos\\SamJessep\\Sudoku-Assignment\\Export\\2x2.csv", false);
            form.MakeSudoku(game);
            //view.Start();
            //view.DrawSudoku(game);
            //view.OpenForm();
            //view.Stop();
        }
    }
}
