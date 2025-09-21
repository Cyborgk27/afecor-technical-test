import { IBaseEntity } from "./common/base-entity.interface";

export interface IProduct extends IBaseEntity<number> {
    name: string,
    cost: number,
    decimal: number,
}