export interface IBaseEntity<TKey> {
    id: number
    auditCreateUser?: string,
    auditCreateDate?: string,
    auditUpdateUser?: string,
    auditUpdateDate?: string,
    auditDeleteUser?: string,
    auditDeleteDate?: string,
    state: 0 | 1
}