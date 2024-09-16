/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';

import { apiBookDelete } from '../fn/book/api-book-delete';
import { ApiBookDelete$Params } from '../fn/book/api-book-delete';
import { apiBookGet } from '../fn/book/api-book-get';
import { ApiBookGet$Params } from '../fn/book/api-book-get';
import { apiBookIdGet } from '../fn/book/api-book-id-get';
import { ApiBookIdGet$Params } from '../fn/book/api-book-id-get';
import { apiBookIdPut } from '../fn/book/api-book-id-put';
import { ApiBookIdPut$Params } from '../fn/book/api-book-id-put';
import { apiBookPost } from '../fn/book/api-book-post';
import { ApiBookPost$Params } from '../fn/book/api-book-post';

@Injectable({ providedIn: 'root' })
export class BookService extends BaseService {
  constructor(config: ApiConfiguration, http: HttpClient) {
    super(config, http);
  }

  /** Path part for operation `apiBookGet()` */
  static readonly ApiBookGetPath = '/api/Book';

  /**
   * Get all books.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiBookGet()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiBookGet$Response(params?: ApiBookGet$Params, context?: HttpContext): Observable<StrictHttpResponse<void>> {
    return apiBookGet(this.http, this.rootUrl, params, context);
  }

  /**
   * Get all books.
   *
   *
   *
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiBookGet$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiBookGet(params?: ApiBookGet$Params, context?: HttpContext): Observable<void> {
    return this.apiBookGet$Response(params, context).pipe(
      map((r: StrictHttpResponse<void>): void => r.body)
    );
  }

  /** Path part for operation `apiBookPost()` */
  static readonly ApiBookPostPath = '/api/Book';

  /**
   * Add a new book.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiBookPost()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiBookPost$Response(params?: ApiBookPost$Params, context?: HttpContext): Observable<StrictHttpResponse<void>> {
    return apiBookPost(this.http, this.rootUrl, params, context);
  }

  /**
   * Add a new book.
   *
   *
   *
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiBookPost$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiBookPost(params?: ApiBookPost$Params, context?: HttpContext): Observable<void> {
    return this.apiBookPost$Response(params, context).pipe(
      map((r: StrictHttpResponse<void>): void => r.body)
    );
  }

  /** Path part for operation `apiBookDelete()` */
  static readonly ApiBookDeletePath = '/api/Book';

  /**
   * Soft delete a book.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiBookDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiBookDelete$Response(params?: ApiBookDelete$Params, context?: HttpContext): Observable<StrictHttpResponse<void>> {
    return apiBookDelete(this.http, this.rootUrl, params, context);
  }

  /**
   * Soft delete a book.
   *
   *
   *
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiBookDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiBookDelete(params?: ApiBookDelete$Params, context?: HttpContext): Observable<void> {
    return this.apiBookDelete$Response(params, context).pipe(
      map((r: StrictHttpResponse<void>): void => r.body)
    );
  }

  /** Path part for operation `apiBookIdGet()` */
  static readonly ApiBookIdGetPath = '/api/Book/{id}';

  /**
   * Get a specific book.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiBookIdGet()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiBookIdGet$Response(params: ApiBookIdGet$Params, context?: HttpContext): Observable<StrictHttpResponse<void>> {
    return apiBookIdGet(this.http, this.rootUrl, params, context);
  }

  /**
   * Get a specific book.
   *
   *
   *
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiBookIdGet$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiBookIdGet(params: ApiBookIdGet$Params, context?: HttpContext): Observable<void> {
    return this.apiBookIdGet$Response(params, context).pipe(
      map((r: StrictHttpResponse<void>): void => r.body)
    );
  }

  /** Path part for operation `apiBookIdPut()` */
  static readonly ApiBookIdPutPath = '/api/Book/{id}';

  /**
   * Update a book.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiBookIdPut()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiBookIdPut$Response(params: ApiBookIdPut$Params, context?: HttpContext): Observable<StrictHttpResponse<void>> {
    return apiBookIdPut(this.http, this.rootUrl, params, context);
  }

  /**
   * Update a book.
   *
   *
   *
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `apiBookIdPut$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiBookIdPut(params: ApiBookIdPut$Params, context?: HttpContext): Observable<void> {
    return this.apiBookIdPut$Response(params, context).pipe(
      map((r: StrictHttpResponse<void>): void => r.body)
    );
  }

}
