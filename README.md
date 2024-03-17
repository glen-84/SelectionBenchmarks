# Selection Benchmarks

## Run

- `docker compose up --detach`
- `dotnet run --project SelectionBenchmarks --configuration Release`
- Select a benchmark to run, or `*` to run them all.

## Example results

### SelectOneField

Use case: n/a (lower baseline).

```
| Method                          | Mean     | Error    | StdDev   | Median   | Gen0   | Gen1   | Allocated |
|-------------------------------- |---------:|---------:|---------:|---------:|-------:|-------:|----------:|
| SelectOneFieldWithProjection    | 576.1 us | 11.29 us | 12.08 us | 577.7 us | 6.8359 |      - |  84.88 KB |
| SelectOneFieldWithoutProjection | 858.7 us | 25.60 us | 73.86 us | 824.7 us | 9.7656 | 1.9531 | 136.77 KB |
```

With projection:
- 33% faster
- 38% less memory

### SelectListData

Use case: An article drop-down list, listing articles with their title (ID as value).

```
| Method                          | Mean     | Error    | StdDev   | Median   | Gen0   | Gen1   | Allocated |
|-------------------------------- |---------:|---------:|---------:|---------:|-------:|-------:|----------:|
| SelectListDataWithProjection    | 614.0 us | 12.90 us | 36.38 us | 600.7 us | 6.8359 |      - |  87.38 KB |
| SelectListDataWithoutProjection | 876.9 us | 22.53 us | 63.90 us | 855.7 us | 9.7656 | 1.9531 | 138.19 KB |
```

With projection:
- 30% faster
- 37% less memory

### SelectIndexData

Use case: An article index page, listing articles with their title/image/publish date/URL.

```
| Method                           | Mean     | Error    | StdDev   | Median   | Gen0    | Gen1   | Allocated |
|--------------------------------- |---------:|---------:|---------:|---------:|--------:|-------:|----------:|
| SelectIndexDataWithProjection    | 616.2 us | 12.32 us | 25.17 us | 613.7 us |  5.8594 |      - |  94.58 KB |
| SelectIndexDataWithoutProjection | 922.1 us | 29.28 us | 84.94 us | 893.9 us | 11.7188 | 1.9531 | 143.42 KB |
```

With projection:
- 33% faster
- 34% less memory

### SelectIndexDataAlt

Use case: An article index page, listing articles with their title/excerpt/image/publish date/author
details/comment count/URL.

```
| Method                              | Mean     | Error    | StdDev   | Gen0    | Allocated |
|------------------------------------ |---------:|---------:|---------:|--------:|----------:|
| SelectIndexDataAltWithProjection    | 770.3 us | 15.38 us | 30.36 us |  7.8125 | 118.64 KB |
| SelectIndexDataAltWithoutProjection | 918.5 us | 26.43 us | 74.54 us | 11.7188 | 157.66 KB |
```

With projection:
- 16% faster
- 25% less memory

### SelectViewData

Use case: An article view page, displaying a single article.

```
| Method                          | Mean     | Error    | StdDev   | Median   | Gen0   | Allocated |
|-------------------------------- |---------:|---------:|---------:|---------:|-------:|----------:|
| SelectViewDataWithProjection    | 767.8 us | 19.83 us | 56.59 us | 749.0 us | 5.8594 |  92.58 KB |
| SelectViewDataWithoutProjection | 678.8 us | 11.53 us |  9.00 us | 681.1 us | 5.8594 |  87.54 KB |
```

With projection:
- 13% slower
- 6% more memory

### SelectAllFieldsExcept

Use case: Remove text fields to reduce performance impact.

```
| Method                                 | Mean     | Error    | StdDev   | Gen0   | Allocated |
|--------------------------------------- |---------:|---------:|---------:|-------:|----------:|
| SelectAllFieldsExceptContent           | 831.0 us | 16.41 us | 28.30 us | 9.7656 | 128.71 KB |
| SelectAllFieldsExceptContentAndExcerpt | 789.8 us | 14.57 us | 31.67 us | 9.7656 | 123.87 KB |
```

### SelectAllFields

Use case: n/a (upper baseline).

```
| Method                           | Mean       | Error    | StdDev   | Median     | Gen0    | Gen1   | Allocated |
|--------------------------------- |-----------:|---------:|---------:|-----------:|--------:|-------:|----------:|
| SelectAllFieldsWithProjection    | 1,040.4 us | 28.04 us | 80.90 us | 1,013.9 us | 17.5781 | 3.9063 | 212.65 KB |
| SelectAllFieldsWithoutProjection |   984.4 us | 32.69 us | 94.31 us |   963.8 us | 15.6250 | 3.9063 | 208.91 KB |
```

With projection:
- 6% slower
- 2% more memory

---

### Summary

- Of the real-world use-cases:
    - `SelectListData`, `SelectIndexData`, and `SelectIndexDataAlt` are faster (16 - 33%) and use less memory (25 - 37%) when using projection.
    - `SelectViewData` is slower (13%) and uses more memory (6%) when using projection.
- `SelectAllFields` is only 6% slower and uses only 2% more memory when using projection, even though this is not a common use case.

## Notes

- The results above are based on running the benchmarks against a database in a Docker container. Running a local or remote database server could show very different results.
- The entities (and the single relationship) are fairly conservative. Real-world entities may contain quite a few more properties (including large text properties) and relationships.
