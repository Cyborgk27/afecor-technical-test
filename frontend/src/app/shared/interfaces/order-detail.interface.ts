import { IBaseEntity } from "./common/base-entity.interface";

export interface IOrderDetail extends IBaseEntity<number> {
    orderId: number,
    productId: number,
    price: number,
    quantity: number,
    subTotal: number,
}