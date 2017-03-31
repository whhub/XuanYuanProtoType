// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: InputMethodContext.proto

#ifndef PROTOBUF_InputMethodContext_2eproto__INCLUDED
#define PROTOBUF_InputMethodContext_2eproto__INCLUDED

#include <string>

#include <google/protobuf/stubs/common.h>

#if GOOGLE_PROTOBUF_VERSION < 2004000
#error This file was generated by a newer version of protoc which is
#error incompatible with your Protocol Buffer headers.  Please update
#error your headers.
#endif
#if 2004001 < GOOGLE_PROTOBUF_MIN_PROTOC_VERSION
#error This file was generated by an older version of protoc which is
#error incompatible with your Protocol Buffer headers.  Please
#error regenerate this file with a newer version of protoc.
#endif

#include <google/protobuf/generated_message_util.h>
#include <google/protobuf/repeated_field.h>
#include <google/protobuf/extension_set.h>
#include <google/protobuf/generated_message_reflection.h>
// @@protoc_insertion_point(includes)

// Internal implementation detail -- do not call these.
void  protobuf_AddDesc_InputMethodContext_2eproto();
void protobuf_AssignDesc_InputMethodContext_2eproto();
void protobuf_ShutdownFile_InputMethodContext_2eproto();

class InputMethodContext;

// ===================================================================

class InputMethodContext : public ::google::protobuf::Message {
 public:
  InputMethodContext();
  virtual ~InputMethodContext();
  
  InputMethodContext(const InputMethodContext& from);
  
  inline InputMethodContext& operator=(const InputMethodContext& from) {
    CopyFrom(from);
    return *this;
  }
  
  inline const ::google::protobuf::UnknownFieldSet& unknown_fields() const {
    return _unknown_fields_;
  }
  
  inline ::google::protobuf::UnknownFieldSet* mutable_unknown_fields() {
    return &_unknown_fields_;
  }
  
  static const ::google::protobuf::Descriptor* descriptor();
  static const InputMethodContext& default_instance();
  
  void Swap(InputMethodContext* other);
  
  // implements Message ----------------------------------------------
  
  InputMethodContext* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const InputMethodContext& from);
  void MergeFrom(const InputMethodContext& from);
  void Clear();
  bool IsInitialized() const;
  
  int ByteSize() const;
  bool MergePartialFromCodedStream(
      ::google::protobuf::io::CodedInputStream* input);
  void SerializeWithCachedSizes(
      ::google::protobuf::io::CodedOutputStream* output) const;
  ::google::protobuf::uint8* SerializeWithCachedSizesToArray(::google::protobuf::uint8* output) const;
  int GetCachedSize() const { return _cached_size_; }
  private:
  void SharedCtor();
  void SharedDtor();
  void SetCachedSize(int size) const;
  public:
  
  ::google::protobuf::Metadata GetMetadata() const;
  
  // nested types ----------------------------------------------------
  
  // accessors -------------------------------------------------------
  
  // optional string Input = 1;
  inline bool has_input() const;
  inline void clear_input();
  static const int kInputFieldNumber = 1;
  inline const ::std::string& input() const;
  inline void set_input(const ::std::string& value);
  inline void set_input(const char* value);
  inline void set_input(const char* value, size_t size);
  inline ::std::string* mutable_input();
  inline ::std::string* release_input();
  
  // optional int32 PageIndex = 2;
  inline bool has_pageindex() const;
  inline void clear_pageindex();
  static const int kPageIndexFieldNumber = 2;
  inline ::google::protobuf::int32 pageindex() const;
  inline void set_pageindex(::google::protobuf::int32 value);
  
  // optional int32 SelectionIndex = 3;
  inline bool has_selectionindex() const;
  inline void clear_selectionindex();
  static const int kSelectionIndexFieldNumber = 3;
  inline ::google::protobuf::int32 selectionindex() const;
  inline void set_selectionindex(::google::protobuf::int32 value);
  
  // repeated string Candidates = 4;
  inline int candidates_size() const;
  inline void clear_candidates();
  static const int kCandidatesFieldNumber = 4;
  inline const ::std::string& candidates(int index) const;
  inline ::std::string* mutable_candidates(int index);
  inline void set_candidates(int index, const ::std::string& value);
  inline void set_candidates(int index, const char* value);
  inline void set_candidates(int index, const char* value, size_t size);
  inline ::std::string* add_candidates();
  inline void add_candidates(const ::std::string& value);
  inline void add_candidates(const char* value);
  inline void add_candidates(const char* value, size_t size);
  inline const ::google::protobuf::RepeatedPtrField< ::std::string>& candidates() const;
  inline ::google::protobuf::RepeatedPtrField< ::std::string>* mutable_candidates();
  
  // @@protoc_insertion_point(class_scope:InputMethodContext)
 private:
  inline void set_has_input();
  inline void clear_has_input();
  inline void set_has_pageindex();
  inline void clear_has_pageindex();
  inline void set_has_selectionindex();
  inline void clear_has_selectionindex();
  
  ::google::protobuf::UnknownFieldSet _unknown_fields_;
  
  ::std::string* input_;
  ::google::protobuf::int32 pageindex_;
  ::google::protobuf::int32 selectionindex_;
  ::google::protobuf::RepeatedPtrField< ::std::string> candidates_;
  
  mutable int _cached_size_;
  ::google::protobuf::uint32 _has_bits_[(4 + 31) / 32];
  
  friend void  protobuf_AddDesc_InputMethodContext_2eproto();
  friend void protobuf_AssignDesc_InputMethodContext_2eproto();
  friend void protobuf_ShutdownFile_InputMethodContext_2eproto();
  
  void InitAsDefaultInstance();
  static InputMethodContext* default_instance_;
};
// ===================================================================


// ===================================================================

// InputMethodContext

// optional string Input = 1;
inline bool InputMethodContext::has_input() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void InputMethodContext::set_has_input() {
  _has_bits_[0] |= 0x00000001u;
}
inline void InputMethodContext::clear_has_input() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void InputMethodContext::clear_input() {
  if (input_ != &::google::protobuf::internal::kEmptyString) {
    input_->clear();
  }
  clear_has_input();
}
inline const ::std::string& InputMethodContext::input() const {
  return *input_;
}
inline void InputMethodContext::set_input(const ::std::string& value) {
  set_has_input();
  if (input_ == &::google::protobuf::internal::kEmptyString) {
    input_ = new ::std::string;
  }
  input_->assign(value);
}
inline void InputMethodContext::set_input(const char* value) {
  set_has_input();
  if (input_ == &::google::protobuf::internal::kEmptyString) {
    input_ = new ::std::string;
  }
  input_->assign(value);
}
inline void InputMethodContext::set_input(const char* value, size_t size) {
  set_has_input();
  if (input_ == &::google::protobuf::internal::kEmptyString) {
    input_ = new ::std::string;
  }
  input_->assign(reinterpret_cast<const char*>(value), size);
}
inline ::std::string* InputMethodContext::mutable_input() {
  set_has_input();
  if (input_ == &::google::protobuf::internal::kEmptyString) {
    input_ = new ::std::string;
  }
  return input_;
}
inline ::std::string* InputMethodContext::release_input() {
  clear_has_input();
  if (input_ == &::google::protobuf::internal::kEmptyString) {
    return NULL;
  } else {
    ::std::string* temp = input_;
    input_ = const_cast< ::std::string*>(&::google::protobuf::internal::kEmptyString);
    return temp;
  }
}

// optional int32 PageIndex = 2;
inline bool InputMethodContext::has_pageindex() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
inline void InputMethodContext::set_has_pageindex() {
  _has_bits_[0] |= 0x00000002u;
}
inline void InputMethodContext::clear_has_pageindex() {
  _has_bits_[0] &= ~0x00000002u;
}
inline void InputMethodContext::clear_pageindex() {
  pageindex_ = 0;
  clear_has_pageindex();
}
inline ::google::protobuf::int32 InputMethodContext::pageindex() const {
  return pageindex_;
}
inline void InputMethodContext::set_pageindex(::google::protobuf::int32 value) {
  set_has_pageindex();
  pageindex_ = value;
}

// optional int32 SelectionIndex = 3;
inline bool InputMethodContext::has_selectionindex() const {
  return (_has_bits_[0] & 0x00000004u) != 0;
}
inline void InputMethodContext::set_has_selectionindex() {
  _has_bits_[0] |= 0x00000004u;
}
inline void InputMethodContext::clear_has_selectionindex() {
  _has_bits_[0] &= ~0x00000004u;
}
inline void InputMethodContext::clear_selectionindex() {
  selectionindex_ = 0;
  clear_has_selectionindex();
}
inline ::google::protobuf::int32 InputMethodContext::selectionindex() const {
  return selectionindex_;
}
inline void InputMethodContext::set_selectionindex(::google::protobuf::int32 value) {
  set_has_selectionindex();
  selectionindex_ = value;
}

// repeated string Candidates = 4;
inline int InputMethodContext::candidates_size() const {
  return candidates_.size();
}
inline void InputMethodContext::clear_candidates() {
  candidates_.Clear();
}
inline const ::std::string& InputMethodContext::candidates(int index) const {
  return candidates_.Get(index);
}
inline ::std::string* InputMethodContext::mutable_candidates(int index) {
  return candidates_.Mutable(index);
}
inline void InputMethodContext::set_candidates(int index, const ::std::string& value) {
  candidates_.Mutable(index)->assign(value);
}
inline void InputMethodContext::set_candidates(int index, const char* value) {
  candidates_.Mutable(index)->assign(value);
}
inline void InputMethodContext::set_candidates(int index, const char* value, size_t size) {
  candidates_.Mutable(index)->assign(
    reinterpret_cast<const char*>(value), size);
}
inline ::std::string* InputMethodContext::add_candidates() {
  return candidates_.Add();
}
inline void InputMethodContext::add_candidates(const ::std::string& value) {
  candidates_.Add()->assign(value);
}
inline void InputMethodContext::add_candidates(const char* value) {
  candidates_.Add()->assign(value);
}
inline void InputMethodContext::add_candidates(const char* value, size_t size) {
  candidates_.Add()->assign(reinterpret_cast<const char*>(value), size);
}
inline const ::google::protobuf::RepeatedPtrField< ::std::string>&
InputMethodContext::candidates() const {
  return candidates_;
}
inline ::google::protobuf::RepeatedPtrField< ::std::string>*
InputMethodContext::mutable_candidates() {
  return &candidates_;
}


// @@protoc_insertion_point(namespace_scope)

#ifndef SWIG
namespace google {
namespace protobuf {


}  // namespace google
}  // namespace protobuf
#endif  // SWIG

// @@protoc_insertion_point(global_scope)

#endif  // PROTOBUF_InputMethodContext_2eproto__INCLUDED