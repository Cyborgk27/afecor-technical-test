import { IBaseEntity } from "./common/base-entity.interface";

export interface IClient extends IBaseEntity<number> {
    firstName: string,
    lastName: string,
    email: string,
    phone: string,
    address: string,
}