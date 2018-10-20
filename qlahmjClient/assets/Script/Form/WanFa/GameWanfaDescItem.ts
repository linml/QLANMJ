/**
 * 玩法描述预制体
 */

const {ccclass, property} = cc._decorator;

@ccclass
export default class GameWanfaDescItem extends cc.Component {
    /**
     * 字段名
     */
    @property(cc.Label)
    lab_name: cc.Label = null;

    /**
     * 字段值
     */
    @property(cc.Label)
    lab_value: cc.Label = null;
  	

    private _cityName: string = null;

    /**
     * 初始化界面显示
     */
    
    public initShow(attr: any): void{
        if (!attr) {
          return;
        }

        if (this.lab_name) {
            this.lab_name.string = attr.name + ":";
        }

        if (this.lab_value) {
          this.lab_value.string = attr.value;
        }
    }

}
