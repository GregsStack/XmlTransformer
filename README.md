
# XmlTransformer

[![License][license-image]][license-url]  

Transform XML files with ease, written in C#.

  
## Usage/Examples

### Docker

The following example maps the current directory on the host with the directory `/var` in the container. The file `web.config` will be transformed using `web.Release.config` and the result written to `web.config`.

```bash
docker run --rm -v "$(pwd):/var" xmltransformer:latest /var/web.config /var/web.Release.config /var/web.config
```

  
## License

XmlTransformer is licensed under the [MIT License (MIT)](LICENSE).

[license-image]: https://img.shields.io/github/license/GregsStack/XmlTransformer.svg?style=flat-square
[license-url]: LICENSE

  