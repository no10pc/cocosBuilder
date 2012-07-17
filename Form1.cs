using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CocosBuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnOk.Click += new EventHandler(btnOk_Click);
        }

        void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtclassName.Text))
            {
               txtcode_h.Text = makeheadCode(txtclassName.Text);
               txtcode_cpp.Text= makecppCode(txtclassName.Text, txtParentScene.Text);
               btnCanel.Enabled = true;
               btnCanel.Click += new EventHandler(btnCanel_Click);
            }
        }

        void btnCanel_Click(object sender, EventArgs e)
        {
            string cppfile = string.Empty;
            string hfile = string.Empty;
            SaveFileDialog dlg = new SaveFileDialog();
            //dlg.RestoreDirectory = true;
            dlg.OverwritePrompt = true;
            dlg.Filter = " All files(*.*)|*.*";
            dlg.FileName = txtclassName.Text;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if(!Directory.Exists(dlg.FileName.ToString()))
                {
                    try
                    {
                        Directory.CreateDirectory(dlg.FileName.ToString());
                    }
                    catch 
                    {
                      
                    }
                   
                }

                cppfile = dlg.FileName.ToString()+"\\"+txtcppFile.Text;
                hfile = dlg.FileName.ToString() + "\\" + txtheadFile.Text;
                if (File.Exists(cppfile))
                    File.Delete(cppfile);
                if (File.Exists(hfile))
                    File.Delete(hfile);
                WriteFileUTF8(cppfile, txtcode_cpp.Text);
                WriteFileUTF8(hfile, txtcode_h.Text);
            }
            
        }

        private void txtclassName_TextChanged(object sender, EventArgs e)
        {
            if (txtclassName.Text.Length > 0)
            {
                txtcppFile.Text = txtclassName.Text + ".cpp";
                txtheadFile.Text = txtclassName.Text + ".h";
            }
            else
            {
                ClearText();
            }
        }

        private void ClearText()
        {
            txtcppFile.Text = "";
            txtheadFile.Text = "";
        }
        private string makeheadCode(string className)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(@"#ifndef {0}_H",className.ToUpper()));
            sb.AppendLine(string.Format(@"#define {0}_H",className.ToUpper()));
            sb.AppendLine(@"#include ""cocos2d.h""");
            sb.AppendLine(@"USING_NS_CC;");
             sb.AppendLine(string.Format(@"class {0} : public CCLayer",className));
            sb.AppendLine(@"{");
            sb.AppendLine(@"public:");
            sb.AppendLine(@"    virtual bool init();");
            sb.AppendLine(@"    virtual void onEnter();");
            sb.AppendLine(@"    static  void Show();");
            sb.AppendLine(@"    void MainMenuCallback(CCObject* pSender);");
            sb.AppendLine(string.Format(@"  LAYER_NODE_FUNC({0});",className));
            sb.AppendLine(@"};");
            sb.AppendLine(@"#endif");
            return sb.ToString();
        }
        private string makecppCode(string className,string pScene)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(@"#include ""{0}.h""",className));
            sb.AppendLine(string.Format(@"#include ""{0}.h""", pScene));
            sb.AppendLine(@"");
            sb.AppendLine(@"USING_NS_CC;");
            sb.AppendLine(@"");
            sb.AppendLine(@"#define LINE_SPACE  30");
            sb.AppendLine(@"");
            sb.AppendLine(@"static CCPoint s_tCurPos = CCPointZero;");
            sb.AppendLine(@"");
            sb.AppendLine(string.Format(@"bool {0}::init()",className));
            sb.AppendLine(@"{    ");
            sb.AppendLine(@"");
            sb.AppendLine(@"    if ( !CCLayer::init() )");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"        return false;");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"    CCLabelTTF* label = CCLabelTTF::create(""MainMenu"", ""Arial"", 20);");
            sb.AppendLine(string.Format(@"    CCMenuItemLabel* pMenuItem = CCMenuItemLabel::create(label, this, menu_selector({0}::MainMenuCallback));",className));
            sb.AppendLine(@"");
            sb.AppendLine(@"    CCMenu* pMenu =CCMenu::create(pMenuItem, NULL);");
            sb.AppendLine(@"    CCSize s = CCDirector::sharedDirector()->getWinSize();");
            sb.AppendLine(@"    pMenu->setPosition( CCPointZero );");
            sb.AppendLine(@"    pMenuItem->setPosition( CCPointMake( s.width - 50, 25) );");
            sb.AppendLine(@"");
            sb.AppendLine(@"    addChild(pMenu, 1);");
            sb.AppendLine(@"    return true;");
            sb.AppendLine(@"}");
            sb.AppendLine(string.Format(@"void {0}::onEnter()",className));
            sb.AppendLine(@"{");
            sb.AppendLine(string.Format(@"    CCLabelTTF* label=CCLabelTTF::create(""{0}"",""Arial"",20);",className));
            sb.AppendLine(@"    CCSize s = CCDirector::sharedDirector()->getWinSize();");
            sb.AppendLine(@"    label->setPosition(ccp(s.width/2,s.height/2));");
            sb.AppendLine(@"    addChild(label,1);");
            sb.AppendLine(@"");
            sb.AppendLine(@"    CCLayer::onEnter();");
            sb.AppendLine(@"}");
            sb.AppendLine(string.Format(@"void {0}::Show()",className));
            sb.AppendLine(@"{    ");
            sb.AppendLine(@"    CCScene *pNewScene = CCScene::node(); ");
            sb.AppendLine(string.Format(@"    {0} *pLayer = {0}::node();",className));
            sb.AppendLine(@"    pNewScene->addChild(pLayer);");
            sb.AppendLine(@"    CCScene *pCurScene = CCDirector::sharedDirector()->getRunningScene();    ");
            sb.AppendLine(@"    if(NULL == pCurScene)");
            sb.AppendLine(@"    {        ");
            sb.AppendLine(@"        CCDirector::sharedDirector()->runWithScene(pNewScene);");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"    else");
            sb.AppendLine(@"    {        ");
            sb.AppendLine(@"        CCDirector::sharedDirector()->replaceScene(pNewScene);");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");
            sb.AppendLine(string.Format(@"void {0}::MainMenuCallback(CCObject* pSender)",className));
            sb.AppendLine(@"{");
            sb.AppendLine(@"    CCScene* pScene = CCScene::create();");
            sb.AppendLine(string.Format(@"    CCLayer* pLayer = new {0}();",pScene));
            sb.AppendLine(@"    pLayer->autorelease();");
            sb.AppendLine(@"    pScene->addChild(pLayer);");
            sb.AppendLine(@"    CCDirector::sharedDirector()->replaceScene(pScene);");
            sb.AppendLine(@"}");

            return sb.ToString();
        }
        public void WriteFile(string FilePath, object StringValue)
        {
            StreamWriter FileWriter = new StreamWriter(FilePath, true, System.Text.Encoding.Default);

            FileWriter.Write(StringValue);

            FileWriter.Close();
        }
        public void WriteFileUTF8(string FilePath, object StringValue)
        {
            StreamWriter FileWriter = new StreamWriter(FilePath, false, System.Text.Encoding.UTF8);

            FileWriter.Write(StringValue);

            FileWriter.Close();
        }
    }
}
