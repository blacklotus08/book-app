/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';

import { bookDelete } from '../fn/book/book-delete';
import { BookDelete$Params } from '../fn/book/book-delete';
import { bookIdGet } from '../fn/book/book-id-get';
import { BookIdGet$Params } from '../fn/book/book-id-get';
import { bookIdPut } from '../fn/book/book-id-put';
import { BookIdPut$Params } from '../fn/book/book-id-put';
import { bookPost } from '../fn/book/book-post';
import { BookPost$Params } from '../fn/book/book-post';
import { booksGet } from '../fn/book/books-get';
import { BooksGet$Params } from '../fn/book/books-get';

@Injectable({ providedIn: 'root' })
export class BookService extends BaseService {
  constructor(config: ApiConfiguration, http: HttpClient) {
    super(config, http);
  }

  /** Path part for operation `booksGet()` */
  static readonly BooksGetPath = '/books';

  /**
   * Get all books.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `booksGet()` instead.
   *
   * This method doesn't expect any request body.
   */
  booksGet$Response(params?: BooksGet$Params, context?: HttpContext): Observable<StrictHttpResponse<void>> {
    return booksGet(this.http, this.rootUrl, params, context);
  }

  /**
   * Get all books.
   *
   *
   *
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `booksGet$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  booksGet(params?: BooksGet$Params, context?: HttpContext): Observable<void> {
    return this.booksGet$Response(params, context).pipe(
      map((r: StrictHttpResponse<void>): void => r.body)
    );
  }

  /** Path part for operation `bookIdGet()` */
  static readonly BookIdGetPath = '/book/{id}';

  /**
   * Get a specific book.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `bookIdGet()` instead.
   *
   * This method doesn't expect any request body.
   */
  bookIdGet$Response(params: BookIdGet$Params, context?: HttpContext): Observable<StrictHttpResponse<void>> {
    return bookIdGet(this.http, this.rootUrl, params, context);
  }

  /**
   * Get a specific book.
   *
   *
   *
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `bookIdGet$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  bookIdGet(params: BookIdGet$Params, context?: HttpContext): Observable<void> {
    return this.bookIdGet$Response(params, context).pipe(
      map((r: StrictHttpResponse<void>): void => r.body)
    );
  }

  /** Path part for operation `bookIdPut()` */
  static readonly BookIdPutPath = '/book/{id}';

  /**
   * Update a book.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `bookIdPut()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  bookIdPut$Response(params: BookIdPut$Params, context?: HttpContext): Observable<StrictHttpResponse<void>> {
    return bookIdPut(this.http, this.rootUrl, params, context);
  }

  /**
   * Update a book.
   *
   *
   *
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `bookIdPut$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  bookIdPut(params: BookIdPut$Params, context?: HttpContext): Observable<void> {
    return this.bookIdPut$Response(params, context).pipe(
      map((r: StrictHttpResponse<void>): void => r.body)
    );
  }

  /** Path part for operation `bookPost()` */
  static readonly BookPostPath = '/book';

  /**
   * Add a new book.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `bookPost()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  bookPost$Response(params?: BookPost$Params, context?: HttpContext): Observable<StrictHttpResponse<void>> {
    return bookPost(this.http, this.rootUrl, params, context);
  }

  /**
   * Add a new book.
   *
   *
   *
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `bookPost$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  bookPost(params?: BookPost$Params, context?: HttpContext): Observable<void> {
    return this.bookPost$Response(params, context).pipe(
      map((r: StrictHttpResponse<void>): void => r.body)
    );
  }

  /** Path part for operation `bookDelete()` */
  static readonly BookDeletePath = '/book';

  /**
   * Soft delete a book.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `bookDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  bookDelete$Response(params?: BookDelete$Params, context?: HttpContext): Observable<StrictHttpResponse<void>> {
    return bookDelete(this.http, this.rootUrl, params, context);
  }

  /**
   * Soft delete a book.
   *
   *
   *
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `bookDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  bookDelete(params?: BookDelete$Params, context?: HttpContext): Observable<void> {
    return this.bookDelete$Response(params, context).pipe(
      map((r: StrictHttpResponse<void>): void => r.body)
    );
  }

}
