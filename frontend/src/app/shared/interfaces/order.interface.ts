import { IBaseEntity } from "./common/base-entity.interface";
import { IOrderDetail } from "./order-detail.interface";

export interface IOrder extends IBaseEntity<number> {
    orderDate: string,
    clientId: number,
    total: number,
    details?: IOrderDetail[]
}