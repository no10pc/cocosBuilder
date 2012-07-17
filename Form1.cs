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
            if (chkTrans.Checked)
            {
            sb.AppendLine(string.Format(@"        {0}", CCTransitionCode("pNewScene")));
            sb.AppendLine(@"        CCDirector::sharedDirector()->replaceScene(transitionRotoZoom);");
            }
            else
            {
                sb.AppendLine(@"      CCDirector::sharedDirector()->replaceScene(pNewScene);");
            }
            sb.AppendLine(@"    }");

            sb.AppendLine(@"}");
            sb.AppendLine(string.Format(@"void {0}::MainMenuCallback(CCObject* pSender)",className));
            sb.AppendLine(@"{");
            sb.AppendLine(@"    CCScene* pScene = CCScene::create();");
            sb.AppendLine(string.Format(@"    CCLayer* pLayer = new {0}();",pScene));
            sb.AppendLine(@"    pLayer->autorelease();");
            sb.AppendLine(@"    pScene->addChild(pLayer);");
            if (chkTrans.Checked)
            {
                sb.AppendLine(string.Format(@"        {0}", CCTransitionCode("pScene")));
                sb.AppendLine(@"    CCDirector::sharedDirector()->replaceScene(transitionRotoZoom);");
            }
            else
            {
                sb.AppendLine(@"      CCDirector::sharedDirector()->replaceScene(pScene);");
            }
            sb.AppendLine(@"}");
  
            return sb.ToString();
        }

        private string CCTransitionCode(string pScene)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int rNo = rand.Next(1, 26);
            List<string> list = new List<string>();
            list.Add("CCTransitionJumpZoom* transitionRotoZoom =CCTransitionJumpZoom::transitionWithDuration(0.9f, "+pScene+");");//跳跃式，本场景先会缩小，然后跳跃进来 
			list.Add("CCTransitionFade* transitionRotoZoom =CCTransitionFade::transitionWithDuration(0.9f, "+pScene+");");//淡出淡入，原场景淡出，新场景淡入 
			list.Add("CCTransitionFade* transitionRotoZoom =CCTransitionFade::transitionWithDuration(0.9f, "+pScene+", ccWHITE);");//如果上一个的函数，带3个参数，则第三个参数就是淡出淡入的颜色 
			list.Add("CCTransitionFlipX* transitionRotoZoom =CCTransitionFlipX::transitionWithDuration(0.9f, "+pScene+", kOrientationLeftOver);");//x轴左翻 
			list.Add("CCTransitionFlipX* transitionRotoZoom =CCTransitionFlipX::transitionWithDuration(0.9f, "+pScene+", kOrientationRightOver);");//x轴右翻 
			list.Add("CCTransitionFlipY* transitionRotoZoom =CCTransitionFlipY::transitionWithDuration(0.9f, "+pScene+", kOrientationUpOver);");//y轴上翻 
			list.Add("CCTransitionFlipY* transitionRotoZoom =CCTransitionFlipY::transitionWithDuration(0.9f, "+pScene+", kOrientationDownOver);");//y轴下翻 
			list.Add("CCTransitionFlipAngular* transitionRotoZoom =CCTransitionFlipAngular::transitionWithDuration(0.9f, "+pScene+", kOrientationLeftOver);");//有角度转的左翻 
			list.Add("CCTransitionFlipAngular* transitionRotoZoom =CCTransitionFlipAngular::transitionWithDuration(0.9f, "+pScene+", kOrientationRightOver);");//有角度转的右翻 
			list.Add("CCTransitionZoomFlipX* transitionRotoZoom =CCTransitionZoomFlipX::transitionWithDuration(0.9f, "+pScene+", kOrientationLeftOver);");//带缩放效果x轴左翻 
			list.Add("CCTransitionZoomFlipX* transitionRotoZoom =CCTransitionZoomFlipX::transitionWithDuration(0.9f, "+pScene+", kOrientationRightOver);");//带缩放效果x轴右翻 
			list.Add("CCTransitionZoomFlipY* transitionRotoZoom =CCTransitionZoomFlipY::transitionWithDuration(0.9f, "+pScene+", kOrientationUpOver);");//带缩放效果y轴上翻 
			list.Add("CCTransitionZoomFlipY* transitionRotoZoom =CCTransitionZoomFlipY::transitionWithDuration(0.9f, "+pScene+", kOrientationDownOver);");//带缩放效果y轴下翻 
			list.Add("CCTransitionZoomFlipAngular* transitionRotoZoom =CCTransitionZoomFlipAngular::transitionWithDuration(0.9f, "+pScene+", kOrientationLeftOver);");//带缩放效果/有角度转的左翻 
			list.Add("CCTransitionZoomFlipAngular* transitionRotoZoom =CCTransitionZoomFlipAngular::transitionWithDuration(0.9f, "+pScene+", kOrientationRightOver);");//带缩放效果有角度转的右翻 
			list.Add("CCTransitionShrinkGrow* transitionRotoZoom =CCTransitionShrinkGrow::transitionWithDuration(0.9f, "+pScene+");");//交错换 
			list.Add("CCTransitionRotoZoom* transitionRotoZoom =CCTransitionRotoZoom::transitionWithDuration(0.9f, "+pScene+");");//转角换 
			list.Add("CCTransitionMoveInL* transitionRotoZoom =CCTransitionMoveInL::transitionWithDuration(0.9f, "+pScene+");");//新场景从左移入覆盖 
			list.Add("CCTransitionMoveInR* transitionRotoZoom =CCTransitionMoveInR::transitionWithDuration(0.9f, "+pScene+");");//新场景从右移入覆盖 
			list.Add("CCTransitionMoveInT* transitionRotoZoom =CCTransitionMoveInT::transitionWithDuration(0.9f, "+pScene+");");//新场景从上移入覆盖 
			list.Add("CCTransitionMoveInB* transitionRotoZoom =CCTransitionMoveInB::transitionWithDuration(0.9f, "+pScene+");");//新场景从下移入覆盖 
			list.Add("CCTransitionSlideInL* transitionRotoZoom =CCTransitionSlideInL::transitionWithDuration(0.9f, "+pScene+");");//场景从左移入推出原场景 
			list.Add("CCTransitionSlideInR* transitionRotoZoom =CCTransitionSlideInR::transitionWithDuration(0.9f, "+pScene+");");//场景从右移入推出原场景 
			list.Add("CCTransitionSlideInT* transitionRotoZoom =CCTransitionSlideInT::transitionWithDuration(0.9f, "+pScene+");");//场景从上移入推出原场景 
			list.Add("CCTransitionSlideInB* transitionRotoZoom =CCTransitionSlideInB::transitionWithDuration(0.9f, "+pScene+");");//场景从下移入推出原场景 
			list.Add("CCTransitionCrossFade* transitionRotoZoom =CCTransitionCrossFade::transitionWithDuration(0.9f,"+pScene+");");//淡出淡入交叉，同时进行 
			//
            
            return list[rNo].ToString();
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
