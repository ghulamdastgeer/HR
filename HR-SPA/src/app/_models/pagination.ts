export interface Pagination {
 currentPage: number;
 itemsperpage: number;
 totalItems: number;
 totalpages: number;
}
export class PaginatedResult<T> {
 result: T;
 pagination: Pagination;
}
