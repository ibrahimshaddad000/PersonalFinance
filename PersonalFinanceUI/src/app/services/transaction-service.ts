import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TransactionDto, TransactionCreateDto, TransactionUpdateDto } from '../models/transaction.model';
import { Observable } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';

@Injectable({
  providedIn: 'root',
})
export class TransactionService {
  private apiUrl = "http://localhost:5007/api/transactions"
  constructor(private http: HttpClient){}

  getTransactions() : Observable<TransactionDto[]>
  {
    return this.http.get<TransactionDto[]>(this.apiUrl);
  }

  getTransactionById(id: number ): Observable<TransactionDto>
  {
    return this.http.get<TransactionDto>(`${this.apiUrl}/${id}`);
  }

  createTransaction(transaction : TransactionCreateDto) : Observable<TransactionCreateDto>
  {
    return this.http.post<TransactionCreateDto>(this.apiUrl, transaction);
  }

  updateTransaction(id: number, transaction: TransactionUpdateDto ): Observable<any>
  {
    return this.http.put(`${this.apiUrl}/${id}`, transaction);
  }

  deleteTransaction(id: number) : Observable<any> 
  {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
 
} 
