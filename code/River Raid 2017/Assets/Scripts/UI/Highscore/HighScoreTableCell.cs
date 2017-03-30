using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tacticsoft.Examples
{


    public class HighScoreTableCell : TableViewCell
    {

        //Inherit from TableViewCell instead of MonoBehavior to use the GameObject
        //containing this component as a cell in a TableView

        public Text _playername;
        public Text _playerscore;

        public void SetPlayerScore(int score)
        {
            Debug.Log(score);
            _playerscore.text = score.ToString();
        }
        public void SetPlayerName(string name)
        {
            _playername.text = name;
        }

        private int m_numTimesBecameVisible;
        public void NotifyBecameVisible()
        {
            m_numTimesBecameVisible++;
            _playerscore.text = "# rows this cell showed : " + m_numTimesBecameVisible.ToString();
        }

    }
}
