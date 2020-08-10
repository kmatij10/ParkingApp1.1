
export interface ProtestListRequest<T> {
    current_page: number;
    data: Array<T>;
    last_page: number;
}