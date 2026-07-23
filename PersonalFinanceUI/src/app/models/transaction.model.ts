export interface TransactionDto {
    id: number;
    title: string;
    amount: number;
    type: string;
    category: string;
    date: string;
  }
  
  export interface TransactionCreateDto {
    title: string;
    amount: number;
    type: string;
    category: string;
    date: string;
  }
  
  export interface TransactionUpdateDto {
    title: string;
    amount: number;
    type: string;
    category: string;
    date: string;
  }