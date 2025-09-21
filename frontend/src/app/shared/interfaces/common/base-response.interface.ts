export interface IBaseResponse<T> {
    isSuccess: boolean,
    statusCodde: number,
    message: string,
    data?: T,
    errors?: string[]
}