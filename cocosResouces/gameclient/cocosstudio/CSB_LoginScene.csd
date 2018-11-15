<GameFile>
  <PropertyGroup Name="CSB_LoginScene" Type="Scene" ID="162ea641-8970-48d9-9590-5378aca1756b" Version="3.10.0.0" />
  <Content ctype="GameProjectContent">
    <Content>
      <Animation Duration="45" Speed="1.0000" ActivedAnimationName="weixindenglu">
        <Timeline ActionTag="463186372" Property="Alpha">
          <IntFrame FrameIndex="0" Value="0">
            <EasingData Type="0" />
          </IntFrame>
          <IntFrame FrameIndex="12" Value="76">
            <EasingData Type="0" />
          </IntFrame>
          <IntFrame FrameIndex="21" Value="25">
            <EasingData Type="0" />
          </IntFrame>
          <IntFrame FrameIndex="35" Value="89">
            <EasingData Type="0" />
          </IntFrame>
          <IntFrame FrameIndex="45" Value="0">
            <EasingData Type="0" />
          </IntFrame>
        </Timeline>
        <Timeline ActionTag="412501792" Property="Scale">
          <ScaleFrame FrameIndex="0" X="1.0000" Y="1.0000">
            <EasingData Type="0" />
          </ScaleFrame>
          <ScaleFrame FrameIndex="12" X="1.1000" Y="1.1000">
            <EasingData Type="0" />
          </ScaleFrame>
          <ScaleFrame FrameIndex="21" X="0.9500" Y="0.9500">
            <EasingData Type="0" />
          </ScaleFrame>
          <ScaleFrame FrameIndex="35" X="1.0250" Y="1.0250">
            <EasingData Type="0" />
          </ScaleFrame>
          <ScaleFrame FrameIndex="45" X="1.0000" Y="1.0000">
            <EasingData Type="0" />
          </ScaleFrame>
        </Timeline>
      </Animation>
      <AnimationList>
        <AnimationInfo Name="weixindenglu" StartIndex="0" EndIndex="65">
          <RenderColor A="255" R="0" G="250" B="154" />
        </AnimationInfo>
      </AnimationList>
      <ObjectData Name="Scene" ctype="GameNodeObjectData">
        <Size X="1280.0000" Y="720.0000" />
        <Children>
          <AbstractNodeData Name="ID_SPRITE_LOGINBG" ActionTag="-1131209914" Tag="28" IconVisible="False" PositionPercentXEnabled="True" PositionPercentYEnabled="True" ctype="SpriteObjectData">
            <Size X="1280.0000" Y="720.0000" />
            <AnchorPoint ScaleX="0.5000" ScaleY="0.5000" />
            <Position X="640.0000" Y="360.0000" />
            <Scale ScaleX="1.0000" ScaleY="1.0000" />
            <CColor A="255" R="255" G="255" B="255" />
            <PrePosition X="0.5000" Y="0.5000" />
            <PreSize X="1.0000" Y="1.0000" />
            <FileData Type="Normal" Path="loading/img_login_bg@2x.png" Plist="" />
            <BlendFunc Src="770" Dst="771" />
          </AbstractNodeData>
          <AbstractNodeData Name="img_bg_kuang" ActionTag="-588980299" Tag="24" IconVisible="False" LeftMargin="0.5049" RightMargin="-0.5049" TopMargin="656.6317" BottomMargin="-0.6317" LeftEage="422" RightEage="422" TopEage="16" BottomEage="16" Scale9OriginX="422" Scale9OriginY="16" Scale9Width="436" Scale9Height="19" ctype="ImageViewObjectData">
            <Size X="1280.0000" Y="64.0000" />
            <AnchorPoint ScaleX="0.5000" />
            <Position X="640.5049" Y="-0.6317" />
            <Scale ScaleX="1.0000" ScaleY="1.0000" />
            <CColor A="255" R="255" G="255" B="255" />
            <PrePosition X="0.5004" Y="-0.0009" />
            <PreSize X="1.0000" Y="0.0889" />
            <FileData Type="Normal" Path="loading/img_login_bgkuang@2x.png" Plist="" />
          </AbstractNodeData>
          <AbstractNodeData Name="ID_SPRITE_LOGO" ActionTag="-304637186" Tag="29" IconVisible="False" PositionPercentXEnabled="True" VerticalEdge="TopEdge" LeftMargin="346.5000" RightMargin="346.5000" TopMargin="136.5600" BottomMargin="412.4400" ctype="SpriteObjectData">
            <Size X="587.0000" Y="171.0000" />
            <AnchorPoint ScaleX="0.5000" ScaleY="0.5000" />
            <Position X="640.0000" Y="497.9400" />
            <Scale ScaleX="1.0000" ScaleY="1.0000" />
            <CColor A="255" R="255" G="255" B="255" />
            <PrePosition X="0.5000" Y="0.6916" />
            <PreSize X="0.4586" Y="0.2375" />
            <FileData Type="Normal" Path="loading/img_login_liuan@2x.png" Plist="" />
            <BlendFunc Src="1" Dst="771" />
          </AbstractNodeData>
          <AbstractNodeData Name="ID_BUTTON_LOGIN_WX" ActionTag="412501792" Tag="41" IconVisible="False" PositionPercentXEnabled="True" VerticalEdge="TopEdge" LeftMargin="497.0000" RightMargin="497.0000" TopMargin="522.8878" BottomMargin="94.1122" TouchEnable="True" FontSize="14" Scale9Enable="True" LeftEage="15" RightEage="15" TopEage="11" BottomEage="11" Scale9OriginX="15" Scale9OriginY="11" Scale9Width="256" Scale9Height="78" ShadowOffsetX="2.0000" ShadowOffsetY="-2.0000" ctype="ButtonObjectData">
            <Size X="286.0000" Y="103.0000" />
            <Children>
              <AbstractNodeData Name="add" ActionTag="463186372" Alpha="0" Tag="16" IconVisible="False" LeftMargin="-0.0003" RightMargin="0.0003" TopMargin="3.0000" ctype="SpriteObjectData">
                <Size X="286.0000" Y="100.0000" />
                <AnchorPoint />
                <Position X="-0.0003" />
                <Scale ScaleX="1.0000" ScaleY="1.0000" />
                <CColor A="255" R="255" G="255" B="255" />
                <PrePosition X="0.0000" />
                <PreSize X="1.0000" Y="0.9709" />
                <FileData Type="Normal" Path="loading/btn_login_wx@2x.png" Plist="" />
                <BlendFunc Src="770" Dst="1" />
              </AbstractNodeData>
            </Children>
            <AnchorPoint ScaleX="0.5000" ScaleY="0.5000" />
            <Position X="640.0000" Y="145.6122" />
            <Scale ScaleX="1.0000" ScaleY="1.0000" />
            <CColor A="255" R="255" G="255" B="255" />
            <PrePosition X="0.5000" Y="0.2022" />
            <PreSize X="0.2234" Y="0.1431" />
            <TextColor A="255" R="65" G="65" B="70" />
            <DisabledFileData Type="Normal" Path="loading/btn_login_wx@2x.png" Plist="" />
            <PressedFileData Type="Normal" Path="loading/btn_login_wx@2x.png" Plist="" />
            <NormalFileData Type="Normal" Path="loading/btn_login_wx@2x.png" Plist="" />
            <OutlineColor A="255" R="255" G="0" B="0" />
            <ShadowColor A="255" R="110" G="110" B="110" />
          </AbstractNodeData>
          <AbstractNodeData Name="ID_BUTTON_LOGIN_YOUKE" ActionTag="901054406" VisibleForFrame="False" Tag="146" IconVisible="False" PositionPercentXEnabled="True" LeftMargin="837.1680" RightMargin="342.8320" TopMargin="540.1274" BottomMargin="129.8726" TouchEnable="True" FontSize="14" ButtonText="游客登录" Scale9Enable="True" LeftEage="15" RightEage="15" TopEage="11" BottomEage="11" Scale9OriginX="15" Scale9OriginY="3" Scale9Width="26" Scale9Height="8" ShadowOffsetX="2.0000" ShadowOffsetY="-2.0000" ctype="ButtonObjectData">
            <Size X="100.0000" Y="50.0000" />
            <AnchorPoint ScaleX="0.3000" ScaleY="0.5000" />
            <Position X="867.1680" Y="154.8726" />
            <Scale ScaleX="1.0000" ScaleY="1.0000" />
            <CColor A="255" R="255" G="255" B="255" />
            <PrePosition X="0.6775" Y="0.2151" />
            <PreSize X="0.0781" Y="0.0694" />
            <TextColor A="255" R="255" G="165" B="0" />
            <OutlineColor A="255" R="255" G="0" B="0" />
            <ShadowColor A="255" R="110" G="110" B="110" />
          </AbstractNodeData>
          <AbstractNodeData Name="Text_1_0" ActionTag="-441179452" Alpha="139" Tag="120" IconVisible="False" VerticalEdge="BottomEdge" LeftMargin="368.1829" RightMargin="31.8171" TopMargin="699.5653" BottomMargin="4.4347" FontSize="16" LabelText="抵制不良游戏  拒绝盗版游戏  注意自我保护  谨防上当受骗  适度游戏益脑  沉迷游戏伤身  合理安排时间  享受健康生活" HorizontalAlignmentType="HT_Center" ShadowOffsetX="2.0000" ShadowOffsetY="-2.0000" ctype="TextObjectData">
            <Size X="880.0000" Y="16.0000" />
            <AnchorPoint ScaleX="0.5000" ScaleY="0.5000" />
            <Position X="808.1829" Y="12.4347" />
            <Scale ScaleX="1.0000" ScaleY="1.0000" />
            <CColor A="255" R="255" G="255" B="255" />
            <PrePosition X="0.6314" Y="0.0173" />
            <PreSize X="0.6875" Y="0.0222" />
            <OutlineColor A="255" R="255" G="0" B="0" />
            <ShadowColor A="255" R="110" G="110" B="110" />
          </AbstractNodeData>
          <AbstractNodeData Name="Text_1_1" ActionTag="23961435" Alpha="140" Tag="121" IconVisible="False" VerticalEdge="BottomEdge" LeftMargin="27.2237" RightMargin="928.7763" TopMargin="699.2662" BottomMargin="3.7338" FontSize="17" LabelText="本网络游戏适合年满18周岁以上的用户使用" HorizontalAlignmentType="HT_Center" ShadowOffsetX="2.0000" ShadowOffsetY="-2.0000" ctype="TextObjectData">
            <Size X="324.0000" Y="17.0000" />
            <AnchorPoint ScaleX="0.5000" ScaleY="0.5000" />
            <Position X="189.2237" Y="12.2338" />
            <Scale ScaleX="1.0000" ScaleY="1.0000" />
            <CColor A="255" R="255" G="255" B="255" />
            <PrePosition X="0.1478" Y="0.0170" />
            <PreSize X="0.2531" Y="0.0236" />
            <OutlineColor A="255" R="255" G="0" B="0" />
            <ShadowColor A="255" R="110" G="110" B="110" />
          </AbstractNodeData>
          <AbstractNodeData Name="CheckBox_1" ActionTag="1272315408" Tag="124" IconVisible="False" HorizontalEdge="RightEdge" VerticalEdge="BottomEdge" LeftMargin="496.6094" RightMargin="758.3906" TopMargin="665.4915" BottomMargin="29.5085" TouchEnable="True" CheckedState="True" ctype="CheckBoxObjectData">
            <Size X="25.0000" Y="25.0000" />
            <AnchorPoint ScaleX="1.0000" ScaleY="0.5010" />
            <Position X="521.6094" Y="42.0335" />
            <Scale ScaleX="1.0000" ScaleY="1.0000" />
            <CColor A="255" R="255" G="255" B="255" />
            <PrePosition X="0.4075" Y="0.0584" />
            <PreSize X="0.0195" Y="0.0347" />
            <NormalBackFileData Type="Normal" Path="loading/img_login_xzkuang@2x.png" Plist="" />
            <PressedBackFileData Type="Normal" Path="loading/img_login_xzkuang@2x.png" Plist="" />
            <DisableBackFileData Type="Normal" Path="loading/img_login_xzkuang@2x.png" Plist="" />
            <NodeNormalFileData Type="Normal" Path="loading/icon_dx4@2x.png" Plist="" />
            <NodeDisableFileData Type="Normal" Path="loading/icon_dx4@2x.png" Plist="" />
          </AbstractNodeData>
          <AbstractNodeData Name="Text_3" ActionTag="296759021" Tag="125" IconVisible="False" VerticalEdge="BottomEdge" LeftMargin="536.9918" RightMargin="691.0082" TopMargin="665.0003" BottomMargin="28.9997" FontSize="26" LabelText="同意" ShadowOffsetX="2.0000" ShadowOffsetY="-2.0000" ctype="TextObjectData">
            <Size X="52.0000" Y="26.0000" />
            <AnchorPoint ScaleX="0.5000" ScaleY="0.5000" />
            <Position X="562.9918" Y="41.9997" />
            <Scale ScaleX="1.0000" ScaleY="1.0000" />
            <CColor A="255" R="117" G="178" B="237" />
            <PrePosition X="0.4398" Y="0.0583" />
            <PreSize X="0.0406" Y="0.0361" />
            <OutlineColor A="255" R="255" G="0" B="0" />
            <ShadowColor A="255" R="110" G="110" B="110" />
          </AbstractNodeData>
          <AbstractNodeData Name="Button_1" ActionTag="-2087766923" Tag="203" IconVisible="False" LeftMargin="604.7061" RightMargin="530.2939" TopMargin="607.8080" BottomMargin="91.1920" TouchEnable="True" FontSize="14" Scale9Enable="True" LeftEage="15" RightEage="15" TopEage="4" BottomEage="4" Scale9OriginX="-15" Scale9OriginY="-4" Scale9Width="30" Scale9Height="8" ShadowOffsetX="2.0000" ShadowOffsetY="-2.0000" ctype="ButtonObjectData">
            <Size X="145.0000" Y="21.0000" />
            <Children>
              <AbstractNodeData Name="Text_3_0" ActionTag="1800373879" Tag="126" IconVisible="False" PositionPercentXEnabled="True" PositionPercentYEnabled="True" LeftMargin="-19.4940" RightMargin="-43.5060" TopMargin="57.1946" BottomMargin="-62.1946" FontSize="26" LabelText="《用户使用协议》" ShadowOffsetX="2.0000" ShadowOffsetY="-2.0000" ctype="TextObjectData">
                <Size X="208.0000" Y="26.0000" />
                <AnchorPoint ScaleX="0.5000" ScaleY="0.5000" />
                <Position X="84.5060" Y="-49.1946" />
                <Scale ScaleX="1.0000" ScaleY="1.0000" />
                <CColor A="255" R="81" G="223" B="244" />
                <PrePosition X="0.5828" Y="-2.3426" />
                <PreSize X="1.4345" Y="1.2381" />
                <OutlineColor A="255" R="255" G="0" B="0" />
                <ShadowColor A="255" R="110" G="110" B="110" />
              </AbstractNodeData>
            </Children>
            <AnchorPoint ScaleY="0.5000" />
            <Position X="604.7061" Y="101.6920" />
            <Scale ScaleX="1.0000" ScaleY="1.0000" />
            <CColor A="255" R="255" G="255" B="255" />
            <PrePosition X="0.4724" Y="0.1412" />
            <PreSize X="0.1133" Y="0.0292" />
            <TextColor A="255" R="65" G="65" B="70" />
            <OutlineColor A="255" R="255" G="0" B="0" />
            <ShadowColor A="255" R="110" G="110" B="110" />
          </AbstractNodeData>
          <AbstractNodeData Name="ID_VERSION" ActionTag="688242940" Tag="285" IconVisible="False" HorizontalEdge="LeftEdge" LeftMargin="1153.1512" RightMargin="30.8488" TopMargin="670.0026" BottomMargin="33.9974" FontSize="16" LabelText="版本：v1.0.0" ShadowOffsetX="2.0000" ShadowOffsetY="-2.0000" ctype="TextObjectData">
            <Size X="96.0000" Y="16.0000" />
            <AnchorPoint ScaleX="0.5000" ScaleY="0.5000" />
            <Position X="1201.1512" Y="41.9974" />
            <Scale ScaleX="1.0000" ScaleY="1.0000" />
            <CColor A="255" R="255" G="255" B="255" />
            <PrePosition X="0.9384" Y="0.0583" />
            <PreSize X="0.0750" Y="0.0222" />
            <OutlineColor A="255" R="255" G="0" B="0" />
            <ShadowColor A="255" R="110" G="110" B="110" />
          </AbstractNodeData>
        </Children>
      </ObjectData>
    </Content>
  </Content>
</GameFile>