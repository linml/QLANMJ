import { SetTextureRes } from "../GameHelp/NiuNiuFunction";
import { TexturePath, CommonTexturePath } from "../GameHelp/GameHelp";

const { ccclass, property } = cc._decorator;

export default class SkinChip extends cc.Sprite {

    public static Width = 63;
    public static Height = 64;

    onLoad() {
        SetTextureRes(TexturePath + "coin", this);
        this.node.width = SkinChip.Width;
        this.node.height = SkinChip.Height;
        this.sizeMode = cc.Sprite.SizeMode.CUSTOM;
    }

}
